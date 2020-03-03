using System;
using UnityEngine;

namespace GameSystem.Common.UI {
    public class DOTweenFrame : Frame {

        [Header("[Animations]")]
        [SerializeField] private DOTweenAnimation showAnimation;
        [SerializeField] private DOTweenAnimation hideAnimation;
        [SerializeField] private DOTweenAnimation pauseAnimation;
        [SerializeField] private DOTweenAnimation resumeAnimation;

        protected override void OnInitialize(HUD hud) {
            InitializeAnimation();
        }

        protected override void OnShow(Action onCompleted = null, bool instant = false) {

            hideAnimation?.ResetState();
            pauseAnimation?.ResetState();

            Logs.Log("show frame: " + this.name);
            this.gameObject.SetActive(true);

            if(instant || !showAnimation) {
                onCompleted?.Invoke();
            }
            else {
                showAnimation.Play(onCompleted, true);
            }
        }

        protected override void OnHide(Action onCompleted = null, bool instant = false) {

            showAnimation?.ResetState();
            resumeAnimation?.ResetState();
            Logs.Log("Hide Frame: " + this.name);
            if(instant || !hideAnimation) {
                this.gameObject.SetActive(false);
                onCompleted?.Invoke();
            }
            else {
                hideAnimation.Play(() => {
                    this.gameObject.SetActive(false);
                    onCompleted?.Invoke();
                },
                true);
            }
        }

        protected override void OnPause(Action onCompleted = null, bool instant = false) {

            showAnimation?.ResetState();
            resumeAnimation?.ResetState();

            if(instant || !pauseAnimation) {
                onCompleted?.Invoke();
            }
            else {
                pauseAnimation.Play(onCompleted, true);
            }
        }

        protected override void OnResume(Action onCompleted = null, bool instant = false) {

            hideAnimation?.ResetState();
            pauseAnimation?.ResetState();

            if(instant || !resumeAnimation) {
                onCompleted?.Invoke();
            }
            else {
                resumeAnimation.Play(onCompleted, true);
            }
        }

        private void InitializeAnimation() {
            showAnimation?.Initialize();
            hideAnimation?.Initialize();
            pauseAnimation?.Initialize();
            resumeAnimation?.Initialize();
        }
    }
}