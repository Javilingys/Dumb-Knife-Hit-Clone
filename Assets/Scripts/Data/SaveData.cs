using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeHitClone.Data
{
    // to convert to JSON, the class must be tagged with System.Serializable
    [System.Serializable]
    public class SaveData
    {
        public bool soundEnable;
        public bool vibrationEnable;
        public int maxScore;
        public int maxStage;
        public int appleCount;

        // hash value calculated from the contents of SaveData
        public string hashValue;

        // constructor to initialize data with default values
        public SaveData()
        {
            soundEnable = true;
            vibrationEnable = true;
            maxScore = 0;
            maxStage = 1;
            appleCount = 0;

            hashValue = String.Empty;
        }
    }
}