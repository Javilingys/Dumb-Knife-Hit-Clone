using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KnifeHitClone.Misc;
using System;

namespace KnifeHitClone.Managers
{
    public class GameManager : SingletonMonobehaviour<GameManager>
    {
        public static event Action<int> OnScoreChanged;

        //private bool isGameOver;
        private int currentScore;
        private int currentStage;

        public int Score 
        {
            get => currentScore;
            set 
            {
                currentScore = value;
                if (currentScore > DataManager.Instance.MaxScore)
                {
                    DataManager.Instance.MaxScore = currentScore;
                }
                OnScoreChanged?.Invoke(currentScore);
            }
        }

        public int Stage
        {
            get => currentStage;
            set
            {
                currentStage = value;
                if (currentStage > DataManager.Instance.MaxStage)
                {
                    DataManager.Instance.MaxStage = currentStage;
                }
            }
        }


        protected override void Awake()
        {
            base.Awake();
            currentScore = 0;
            currentStage = 1;
        }

        private void Start()
        {
            LevelManager.Instance.StartFirstLevel();
        }
    }
}