using UnityEngine;

namespace KnifeHitClone.Data
{
    [System.Serializable]
    public class LevelData
    {
        // For Editor
        public string levelName;
        [Range(1, 9)]
        public int knifeCount;

        public WheelData wheelData;
    }
}