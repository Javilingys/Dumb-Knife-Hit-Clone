using KnifeHitClone.Data;
using KnifeHitClone.Misc;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeHitClone.Managers
{
    public class DataManager : SingletonMonobehaviour<DataManager>
    {
        private SaveData _saveData;
        private JsonSaver _jsonSaver;

        // public properties to set and get values from the SaveData object
        public bool SoundEnable
        {
            get { return _saveData.soundEnable; }
            set { _saveData.soundEnable = value; }
        }

        public bool VibrationEnable
        {
            get { return _saveData.vibrationEnable; }
            set { _saveData.vibrationEnable = value; }
        }

        public int MaxScore
        {
            get { return _saveData.maxScore; }
            set { _saveData.maxScore = value; }
        }

        public int MaxStage
        {
            get { return _saveData.maxStage; }
            set { _saveData.maxStage = value; }
        }

        public int AppleCount
        {
            get { return _saveData.appleCount; }
            set { _saveData.appleCount = value; }
        }

        // initialize SaveData and JsonSaver objects
        protected override void Awake()
        {
            base.Awake();
            if (Instance == this)
            {
                _saveData = new SaveData();
                _jsonSaver = new JsonSaver();
            }
        }

        // save the data using the JsonSaver
        public void Save()
        {
            _jsonSaver.Save(_saveData);
        }

        // load the data using the JsonSaver
        public void Load()
        {
            _jsonSaver.Load(_saveData);
        }
    }
}