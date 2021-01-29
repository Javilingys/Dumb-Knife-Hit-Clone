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
        public static event Action OnStageChanged;

        //private bool isGameOver;
        private int currentScore;
        private int currentStage;

        private float timeToDestroyObjects = 1.5f;
        public float TimeToDestroyObjects { get => timeToDestroyObjects; private set => timeToDestroyObjects = value; }

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
                OnStageChanged?.Invoke();
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
            Wheel.OnWheelDestroy += Wheel_OnWheelDestroy;
            Knife.OnAppleHit += Knife_OnAppleHit;
        }

        private void Wheel_OnWheelDestroy()
        {
            Stage++;
            StartCoroutine(nameof(StartNextStage));
        }

        private IEnumerator StartNextStage()
        {
            yield return new WaitForSeconds(timeToDestroyObjects);
            LevelManager.Instance.StartAnotherLevel(currentStage - 1);
        }

        private void Start()
        {
            LevelManager.Instance.StartFirstLevel();
        }

        private void OnDisable()
        {
            Wheel.OnKnifeHit -= Wheel_OnKnifeHit;
            Wheel.OnWheelDestroy -= Wheel_OnWheelDestroy;
            Knife.OnAppleHit -= Knife_OnAppleHit;
        }

        private void Wheel_OnKnifeHit()
        {
            Score++;
        }

        private void Knife_OnAppleHit()
        {
            DataManager.Instance.AppleCount++;
            DataManager.Instance.Save();
        }
    }
}