using KnifeHitClone.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeHitClone.Game
{
    public class WheelSpawner : MonoBehaviour
    {
        [SerializeField]
        private Transform spawnPoint;
        [SerializeField]
        private Wheel prefab;

        public void SpawnWheel(WheelData wheelData)
        {
            Wheel wheel = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
            wheel.InitWheel(wheelData);
        }
    }
}