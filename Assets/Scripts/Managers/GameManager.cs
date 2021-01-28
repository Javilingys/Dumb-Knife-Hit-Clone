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
        private int maxScore;
        private int score;
        private int currentStage;

        public int Score 
        {
            get => score;
            set 
            {
                score = value;
                if (score > MaxScore)
                {
                    MaxScore = score;
                }
                OnScoreChanged?.Invoke(score);
            }
        }
        public int CurrentStage { get => currentStage; set => currentStage = value; }
        public int MaxScore { get => maxScore; set => maxScore = value; }

        protected override void Awake()
        {
            base.Awake();
        }
    }
}