﻿using System.Collections.Generic;
using UnityEngine;

namespace GameSystem.Common.UI {
    public class DOTweenAnimation : MonoBehaviour {

        private class DOTweenTransitionComparer : IComparer<DOTweenTransition> {
            public int Compare(DOTweenTransition x, DOTweenTransition y) {
                return y.TotalDuration.CompareTo(x.TotalDuration);
            }
        }

        [Header("[Transitions]")]
        [SerializeField] private DOTweenTransition[] transitions;
        private static DOTweenTransitionComparer comparer = new DOTweenTransitionComparer();

        private void Reset() {
            transitions = GetComponents<DOTweenTransition>();
        }

        private void OnValidate() {
            Reset();
        }

        public void Initialize() {
            System.Array.Sort(transitions, comparer);
        }

        public void ResetState() {
            foreach (DOTweenTransition transition in transitions) {
                transition.Stop();
                transition.ResetState();
            }
        }

        public void Stop(bool onComplete = false) {
            foreach (DOTweenTransition transition in transitions) {
                transition.Stop();
            }
        }

        public void Play() {
            Play(null, true);
        }

        public void Play(System.Action onCompleted, bool restart) {
            Stop(false);

            if (transitions.Length <= 0) {
                onCompleted?.Invoke();
            } else {
                transitions[0].DoTransition(onCompleted, restart);
                for (int i = 1; i < transitions.Length; i++) {
                    transitions[i].DoTransition(null, restart);
                }
            }
        }
    }
}

