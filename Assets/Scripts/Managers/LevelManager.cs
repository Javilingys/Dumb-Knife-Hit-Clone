using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KnifeHitClone.Misc;
using KnifeHitClone.Game;
using KnifeHitClone.Data;
using KnifeHitClone.UI;

namespace KnifeHitClone.Managers
{
    public class LevelManager : SingletonMonobehaviour<LevelManager>
    {
        [SerializeField]
        private LevelsDataSetSO levelsDataSet = null;

        private WheelSpawner wheelSpawner;
        private KnifeSpawner knifeSpawner;

        #region Unity Methods
        protected override void Awake()
        {
            base.Awake();
            if (Instance == this)
            {
                wheelSpawner = FindObjectOfType<WheelSpawner>();
                knifeSpawner = FindObjectOfType<KnifeSpawner>();
            }
        }
        #endregion

        #region Public Methods
        public void StartFirstLevel()
        {
            wheelSpawner.SpawnWheel(levelsDataSet.GetWheelDataByIndex(0));
            knifeSpawner.InitKnifeSpawner(levelsDataSet.GetKnifeCountByIndex(0));
            GameMenu.Instance.SetStartKnifesSet(levelsDataSet.GetKnifeCountByIndex(0));
        }
        #endregion

        #region Private Methods
        #endregion
    }
}