using Cinemachine;
using KnifeHitClone.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeHitClone.Feedback
{
    public class ShakeCinemachineFeedback : MonoBehaviour
    {
        [SerializeField]
        [Range(0, 5)]
        private float amplitude = 1, intensity = 1;
        [SerializeField]
        [Range(0, 1)]
        private float duration = 0.1f;

        private CinemachineVirtualCamera cinemachineCamera;
        private CinemachineBasicMultiChannelPerlin noise;

        private void Awake()
        {
            cinemachineCamera = GetComponent<CinemachineVirtualCamera>();
            if (cinemachineCamera == null)
                cinemachineCamera = FindObjectOfType<CinemachineVirtualCamera>();
            noise = cinemachineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }

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
            StopAllCoroutines();
            noise.m_AmplitudeGain = 0;
        }

        private void CreateFeedback()
        {
            noise.m_AmplitudeGain = amplitude;
            noise.m_FrequencyGain = intensity;
            StartCoroutine(ShakeRoutine());
        }

        private IEnumerator ShakeRoutine()
        {
            for (float i = duration; i > 0; i-=Time.deltaTime)
            {
                noise.m_AmplitudeGain = Mathf.Lerp(0, amplitude, i / duration);
                yield return null;
            }
            noise.m_AmplitudeGain = 0;
        }
    }
}