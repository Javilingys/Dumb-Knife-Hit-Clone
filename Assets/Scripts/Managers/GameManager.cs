using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KnifeHitClone.Misc;
using System;
using KnifeHitClone.Game;

namespace KnifeHitClone.Managers
{
    public class GameManager : SingletonMonobehaviour<GameManager>
    {
        public static event Action OnScoreChanged;

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
                OnScoreChanged?.Invoke();
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

        private void OnEnable()
        {
            Wheel.OnKnifeHit += Wheel_OnKnifeHit;
        }

        private void Start()
        {
            LevelManager.Instance.StartFirstLevel();
        }

        private void OnDisable()
        {
            Wheel.OnKnifeHit -= Wheel_OnKnifeHit;
        }

        private void Wheel_OnKnifeHit()
        {
            Score++;
        }
    }
}