using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Levels/Create new level dataset", fileName = "new Levels")]
public class LevelsDataSetSO : ScriptableObject
{
    [SerializeField]
    private List<LevelData> levels;

    public WheelData GetWheelDataByIndex(int level)
    {
        return levels[level].wheelData;
    }

    public WheelData GetWheelSpriteByIndex(int level)
    {
        return levels[level].wheelData;
    }
}
