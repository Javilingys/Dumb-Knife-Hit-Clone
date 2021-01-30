using KnifeHitClone.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeHitClone.AudioSystem
{
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField]
        private SoundAudioClip[] sounds;

        public SoundAudioClip[] Sounds => sounds;
    }

    [System.Serializable]
    public class SoundAudioClip
    {
        public string soundName;
        public AudioManager.Sound sound;
        public AudioClip audioClip;
    }
}