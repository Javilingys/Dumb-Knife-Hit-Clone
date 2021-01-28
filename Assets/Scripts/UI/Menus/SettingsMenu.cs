using KnifeHitClone.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace KnifeHitClone.UI
{
    public class SettingsMenu : Menu<SettingsMenu>
    {
        // Only number
        [SerializeField]
        private TextMeshProUGUI appleText;
        [SerializeField]
        private GameObject soundOn;
        [SerializeField]
        private GameObject soundOff;
        [SerializeField]
        private GameObject vibroOn;
        [SerializeField]
        private GameObject vibroOff;

        private void Start()
        {
            LoadData();
        }

        private void LoadData()
        {
            DataManager.Instance.Load();

            appleText.text = DataManager.Instance.AppleCount.ToString();
            SetSoundBtnActive(DataManager.Instance.SoundEnable);
            SetVibroBtnActive(DataManager.Instance.VibrationEnable);
        }

        public void ToggleSoundsBtn()
        {
            if (soundOn.activeSelf)
            {
                SetSoundBtnActive(false);
                DataManager.Instance.SoundEnable = false;
            }
            else
            {
                SetSoundBtnActive(true);
                DataManager.Instance.SoundEnable = true;
            }
        }

        public void ToggleVibroBtn()
        {
            if (vibroOn.activeSelf)
            {
                SetVibroBtnActive(false);
                DataManager.Instance.VibrationEnable = false;
            }
            else
            {
                SetVibroBtnActive(true);
                DataManager.Instance.VibrationEnable = true;
            }
        }

        public override void OnBackPressed()
        {
            DataManager.Instance.Save();
            base.OnBackPressed();
        }

        private void SetSoundBtnActive(bool enable)
        {
            if (enable == true)
            {
                soundOn.SetActive(true);
                soundOff.SetActive(false);
            }
            else
            {
                soundOn.SetActive(false);
                soundOff.SetActive(true);
            }
        }

        private void SetVibroBtnActive(bool enable)
        {
            if (enable == true)
            {
                vibroOn.SetActive(true);
                vibroOff.SetActive(false);
            }
            else
            {
                vibroOn.SetActive(false);
                vibroOff.SetActive(true);
            }
        }
    }
}