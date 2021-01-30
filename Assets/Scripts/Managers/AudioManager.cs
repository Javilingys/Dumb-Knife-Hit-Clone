using KnifeHitClone.AudioSystem;
using KnifeHitClone.Misc;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeHitClone.Managers
{
    [RequireComponent(typeof(AudioPlayer))]
    public class AudioManager : SingletonMonobehaviour<AudioManager>
    {
        public enum Sound
        {
            AppleHit,
            Button,
            GameOver,
            KnifeFire,
            KnifeHit,
            WheelHit
        }

        private AudioPlayer audioPlayer;

        protected override void Awake()
        {
            base.Awake();
            if (Instance == this)
            {
                audioPlayer = GetComponent<AudioPlayer>();
            }
        }

        public void PlaySound(Sound sound)
        {
            GameObject soundGameObject = new GameObject("Sound");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.PlayOneShot(GetAudioClip(sound));
        }

        private AudioClip GetAudioClip(Sound sound)
        {
            foreach  (SoundAudioClip soundAudioClip in audioPlayer.Sounds)
            {
                if (soundAudioClip.sound == sound)
                {
                    return soundAudioClip.audioClip;
                }
            }

            return null;
        }
    }
}