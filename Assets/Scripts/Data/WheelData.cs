using System.Collections.Generic;
using UnityEngine;

namespace KnifeHitClone.Data
{
    [System.Serializable]
    public class WheelData
    {
        public float speed;
        public Sprite wheelSprite;
        public GameObject destryoedWheelPrefab;
        [Range(0f, 1f)]
        public float chanceOfAppleSpawn = .25f;
        [Range(1, 3)]
        public int knifesSpawnCount = 1;
        public bool isBoss;
        public float[] anglesForAppleSpawn;
        public float[] anglesForKnifeSpawn;
    }
}