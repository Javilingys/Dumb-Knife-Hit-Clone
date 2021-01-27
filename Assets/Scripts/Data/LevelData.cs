using UnityEngine;

[System.Serializable]
public class LevelData
{
    public string levelName;
    public int knifeCount;
    [Range(0f, 1f)]
    public float chanceOfAppleSpawn;
    [Range(1, 3)]
    public int knifesSpawnCount;
    public WheelData wheelData;
}
