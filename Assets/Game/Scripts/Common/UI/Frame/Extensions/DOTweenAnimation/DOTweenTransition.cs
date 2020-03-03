﻿using UnityEngine;
using System;
using DG.Tweening;

namespace GameSystem.Common.UI {
    public abstract class DOTweenTransition : MonoBehaviour {
        [SerializeField, Range(0f, 10f)] private float delay = 0f;
        [SerializeField, Range(0f, 10f)] private float duration = 0.5f;
        [SerializeField] private Ease ease = Ease.Linear;
        [SerializeField] private bool ignoreTimeScale = false;
        
        public float Duration { get => duration; }
        public float Delay { get => delay; }
        public float TotalDuration { get => Duration + Delay; }
        public Ease Ease { get => ease; }
        public bool IgnoreTimeScale { get => ignoreTimeScale; }
        public Tween Tween { get; protected set; }

        public void Stop() {
            Tween?.Kill(false);
        }
        public abstract void ResetState();
        public abstract void DoTransition(Action onCompleted, bool restart);
    }
}