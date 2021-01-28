using System.Collections.Generic;
using UnityEngine;

namespace KnifeHitClone.Data
{
    [CreateAssetMenu(menuName = "Levels/Create new level dataset", fileName = "new Levels")]
    public class LevelsDataSetSO : ScriptableObject
    {
        [SerializeField]
        private List<LevelData> levels;

        public WheelData GetWheelDataByIndex(int level)
        {
            return levels[level].wheelData;
        }

        public int GetKnifeCountByIndex(int level)
        {
            return levels[level].knifeCount;
        }
    }
}