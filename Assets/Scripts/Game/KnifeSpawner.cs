using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeHitClone.Game
{
    public class KnifeSpawner : MonoBehaviour
    {
        public static event Action OnListEmpty;

        [SerializeField]
        private Transform spawnPoint;
        [SerializeField]
        private Knife knifePrefab;

        private int countForSpawn = 1;

        private List<Knife> spawnedKnifes;

        private void Awake()
        {
            spawnedKnifes = new List<Knife>();
        }

        public void InitKnifeSpawner(int knifesCount)
        {
            countForSpawn = knifesCount;
            SpawnKnifes();
        }

        private void SpawnKnifes()
        {
            for (int i = 0; i < countForSpawn; i++)
            {
                Knife knife = Instantiate(knifePrefab, spawnPoint.position, Quaternion.identity);
                knife.gameObject.SetActive(false);
                knife.OnWheelHit += SpawnNextKnife;
                spawnedKnifes.Add(knife);
            }
            if (spawnedKnifes.Count > 0)
            {
                spawnedKnifes[0].gameObject.SetActive(true);
            }
        }

        private void SpawnNextKnife()
        {
            DeleteCurrentKnife();
            if (spawnedKnifes.Count > 0)
            {
                spawnedKnifes[0].gameObject.SetActive(true);
            }
            else
            {
                OnListEmpty?.Invoke();
            }
        }

        private void DeleteCurrentKnife()
        {
            if (spawnedKnifes.Count > 0)
            {
                Knife knife = spawnedKnifes[0];
                knife.OnWheelHit -= SpawnNextKnife;
                spawnedKnifes.RemoveAt(0);
            }
        }
    }
}