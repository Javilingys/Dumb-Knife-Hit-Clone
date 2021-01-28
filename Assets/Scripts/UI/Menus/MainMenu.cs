using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using KnifeHitClone.Managers;
using KnifeHitClone.Game;

namespace KnifeHitClone.UI
{
    public class MainMenu : Menu<MainMenu>
    {
        // Only number
        [SerializeField]
        private TextMeshProUGUI appleText;
        // STAGE + number
        [SerializeField]
        private TextMeshProUGUI stageText;
        // SCORE + number
        [SerializeField]
        private TextMeshProUGUI scoreText;


        protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            LoadData();
        }

        private void LoadData()
        {
            DataManager.Instance.Load();
            appleText.text = DataManager.Instance.AppleCount.ToString();
            stageText.text = $"STAGE {DataManager.Instance.MaxStage}";
            scoreText.text = $"SCORE {DataManager.Instance.MaxScore}";
        }

        public void OnPlayPressed()
        {
            GameMenu.Open();
            LevelLoader.LoadNextLevel();
        }

        // open the SettingsMenu
        public void OnSettingsPressed()
        {
            SettingsMenu.Open();
        }

        // quit the application
        public override void OnBackPressed()
        {
            Application.Quit();
        }
    }
}