using KnifeHitClone.Managers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace KnifeHitClone.UI
{
    public class EndGameMenu : Menu<EndGameMenu>
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
        [SerializeField]
        private GameObject newBest;

        private void OnEnable()
        {
            newBest.SetActive(false);
            LoadData();
        }

        private void OnDisable()
        {
            
        }

        private void LoadData()
        {
            if (DataManager.Instance != null && GameManager.Instance != null)
            {
                appleText.text = DataManager.Instance.AppleCount.ToString();
                stageText.text = $"STAGE {GameManager.Instance.Stage}";
                scoreText.text = GameManager.Instance.Score.ToString();
                if (GameManager.Instance.isBestScore)
                {
                    newBest.SetActive(true);
                }
            }
        }

        public void OnRestartPressed()
        {
            StartCoroutine(RestartGame());
        }

        public void OnHomePressed()
        {
            StartCoroutine(LoadMainMenu());
        }

        private IEnumerator RestartGame()
        {
            yield return LevelLoader.ReloadLevel();
            DataManager.Instance.Save();
            OnBackPressed();
        }

        private IEnumerator LoadMainMenu()
        {
            yield return LevelLoader.LoadMainMenuLevel();
            DataManager.Instance.Save();
            MainMenu.Open();
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
        }
    }
}