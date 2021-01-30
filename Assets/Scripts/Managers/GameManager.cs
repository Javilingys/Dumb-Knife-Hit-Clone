using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KnifeHitClone.Misc;
using System;
using KnifeHitClone.Game;
using KnifeHitClone.UI;

namespace KnifeHitClone.Managers
{
    public class GameManager : SingletonMonobehaviour<GameManager>
    {
        // Trigger if current score changes. Need for UI (GameMenuUI)
        public static event Action OnScoreChanged;
        // Trugger if current stage is changed. Need for UI (GameMenuUI)
        public static event Action OnStageChanged;

        //private bool isGameOver;
        private int currentScore;
        private int currentStage;

        // reference time for synchronize destruction knife and wheel and spaw only after destroy all objects
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
                    isBestScore = true;
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

        public bool isBestScore = false;

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
            Knife.OnDeathKnifeHit += OpenLoseMenu;
        }

        private void OpenLoseMenu()
        {
            StartCoroutine(nameof(OpenLoseMenuRoutine));
        }

        private void Wheel_OnWheelDestroy()
        {
            Stage++;
            StartCoroutine(nameof(StartNextStage));
        }

        private IEnumerator StartNextStage()
        {
            yield return new WaitForSeconds(timeToDestroyObjects + 0.001f);
            LevelManager.Instance.StartAnotherLevel(currentStage - 1);
        }

        public IEnumerator OpenLoseMenuRoutine()
        {
            yield return new WaitForSeconds(timeToDestroyObjects + 0.001f);
            DataManager.Instance.Save();
            EndGameMenu.Open();
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
            Knife.OnDeathKnifeHit -= OpenLoseMenu;
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