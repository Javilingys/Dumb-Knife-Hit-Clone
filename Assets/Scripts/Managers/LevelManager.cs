using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KnifeHitClone.Misc;

public class LevelManager : SingletonMonobehaviour<LevelManager>
{
    [SerializeField]
    private LevelsDataSetSO levelsDataSet = null;

    private WheelSpawner wheelSpawner;

    #region Unity Methods
    protected override void Awake()
    {
        base.Awake();
        if (Instance == this)
        {
            wheelSpawner = FindObjectOfType<WheelSpawner>();
        }
    }

    private void Start()
    {
        StartFirstLevel();
    }
    #endregion

    #region Public Methods
    public void StartFirstLevel()
    {
        wheelSpawner.SpawnWheel(levelsDataSet.GetWheelDataByIndex(0));
    }
    #endregion

    #region Private Methods
    #endregion
}
