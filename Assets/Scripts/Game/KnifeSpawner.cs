using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeHitClone.Game
{
    public class KnifeSpawner : MonoBehaviour
    {
        [SerializeField]
        private Transform spawnPoint;
        [SerializeField]
        private Knife knifePrefab;

        private void Start()
        {
            Instantiate(knifePrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}