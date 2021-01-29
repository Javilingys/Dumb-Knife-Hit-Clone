using KnifeHitClone.Game;
using KnifeHitClone.Misc;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using KnifeHitClone.Managers;

namespace KnifeHitClone.UI
{
    public class GameMenu : Menu<GameMenu>
    {
        [SerializeField]
        private SpriteToggler knifePrefabUI;
        [SerializeField]
        private GameObject knifesPanel;
        [SerializeField]
        private TextMeshProUGUI appleText;
        [SerializeField]
        private TextMeshProUGUI scoreText;
        [SerializeField]
        private TextMeshProUGUI stageText;

        private Queue<SpriteToggler> knifes = new Queue<SpriteToggler>();

        private void OnEnable()
        {
            Knife.OnRelease += UpdateKnifeBar;
            GameManager.OnScoreChanged += UpdateScoreText;
            GameManager.OnStageChanged += GameManager_OnStageChanged;
            DataManager.OnAppleChange += DataManager_OnAppleChange;
        }

        private void GameManager_OnStageChanged()
        {
            stageText.text = $"STAGE {GameManager.Instance.Stage}";
        }

        private void DataManager_OnAppleChange()
        {
            appleText.text = DataManager.Instance.AppleCount.ToString();
        }

        private void UpdateScoreText()
        {
            scoreText.text = GameManager.Instance.Score.ToString();
        }

        private void Start()
        {
            appleText.text = DataManager.Instance.AppleCount.ToString();
            scoreText.text = GameManager.Instance.Score.ToString();
            stageText.text = $"STAGE {GameManager.Instance.Stage}";
        }

        private void OnDisable()
        {
            Knife.OnRelease -= UpdateKnifeBar;
            GameManager.OnScoreChanged -= UpdateScoreText;
            GameManager.OnStageChanged -= GameManager_OnStageChanged;
            DataManager.OnAppleChange -= DataManager_OnAppleChange;
        }

        public void SetStartKnifesSet(int knifeCount)
        {
            ClearAllKnifeSprites();

            for (int i = 0; i < knifeCount; i++)
            {
                SpriteToggler knife = Instantiate(knifePrefabUI, knifesPanel.transform);
                knife.SetEnableSprite(true);
                knifes.Enqueue(knife);
            }
        }

        private void ClearAllKnifeSprites()
        {
            foreach (Transform child in knifesPanel.transform)
            {
                Destroy(child.gameObject);
            }
        }

        private void UpdateKnifeBar()
        {
            if (knifes.Count > 0)
            {
                SpriteToggler knife = knifes.Dequeue();
                knife.SetEnableSprite(false);
            }
        }
    }
}