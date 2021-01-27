using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Levels/Create new level dataset", fileName = "new Levels")]
public class LevelSO : ScriptableObject
{
    [SerializeField]
    private List<LevelData> levels;
}
