using KnifeHitClone.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeHitClone.Feedback
{
    public class HapticFeedback : MonoBehaviour
    {
        private void OnEnable()
        {
            Knife.OnDeathKnifeHit += PlayFeedback;
            Wheel.OnKnifeHit += PlayFeedback;
            Wheel.OnWheelDestroy += PlayFeedback;
        }

        private void OnDisable()
        {
            Knife.OnDeathKnifeHit -= PlayFeedback;
            Wheel.OnKnifeHit -= PlayFeedback;
            Wheel.OnWheelDestroy -= PlayFeedback;
        }

        private void Start()
        {
            Vibration.Init();
        }

        public void PlayFeedback()
        {
            FinishFeedback();
            CreateFeedback();
        }

        private void FinishFeedback()
        {
            CompletePreviousFeedback();
        }

        private void CompletePreviousFeedback()
        {
            Vibration.Cancel();
        }

        private void CreateFeedback()
        {
            Vibration.VibratePeek();
        }
    }
}