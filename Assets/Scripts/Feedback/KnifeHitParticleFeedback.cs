using KnifeHitClone.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeHitClone.Feedback
{
    [RequireComponent(typeof(ParticleSystem))]
    public class KnifeHitParticleFeedback : MonoBehaviour
    {
        private ParticleSystem particleEffect;

        private void Awake()
        {
            particleEffect = GetComponent<ParticleSystem>();
        }

        private void OnEnable()
        {
            Wheel.OnKnifeHit += PlayFeedback;
        }

        private void OnDisable()
        {
            Wheel.OnKnifeHit -= PlayFeedback;
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
            
        }

        private void CreateFeedback()
        {
            if (!particleEffect.isPlaying)
            {
                particleEffect.Play();
            }
        }
    }
}