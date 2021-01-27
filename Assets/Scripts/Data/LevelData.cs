using UnityEngine;

[System.Serializable]
public class LevelData
{
    public string levelName;
    public int knifeCount;
    [Range(0f, 1f)]
    public float chanceOfAppleSpawn;
    public WheelData wheelData;
}
