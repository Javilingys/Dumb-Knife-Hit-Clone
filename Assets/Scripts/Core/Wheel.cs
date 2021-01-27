using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KnifeHitClone.Misc;

namespace KnifeHitClone.Core
{
    public class Wheel : MonoBehaviour
    {
        [SerializeField]
        private float speed = 80f;
        [SerializeField]
        private Transform applePrefab = null;
        [SerializeField]
        private Transform applePrefabPoint = null;

        [SerializeField]
        private Vector3 position;

        private void Start()
        {

        }

        private void SpawnApple()
        {
            Vector2 dir = Utils.GetRandomDir();
            Transform apple = Instantiate(applePrefab, applePrefabPoint);
            float appleRadius = apple.GetComponent<CircleCollider2D>().radius;
            Vector2 spawnPoint = (GetComponent<CircleCollider2D>().radius + appleRadius) * dir;

            Vector3 directionFinal = applePrefabPoint.position - apple.transform.position;

            apple.localPosition = spawnPoint;
 
        }

        private void Update()
        {            
            transform.Rotate(new Vector3(0f, 0f, speed * Time.deltaTime));
        }

    }
}