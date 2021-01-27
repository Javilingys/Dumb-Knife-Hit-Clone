using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KnifeHitClone.Misc;

namespace KnifeHitClone.Core
{
    public class Wheel : MonoBehaviour
    {
        [SerializeField]
        private int availableKnifes;
        [SerializeField]
        private Sprite firstWheel;
        [SerializeField]
        private Sprite secondWheel;
        [SerializeField]
        private Sprite firdWheel;
        [SerializeField]
        private bool isBoss;

        [Header("Prefabs")]
        [SerializeField]
        private GameObject applePrefab;
        [SerializeField]
        private GameObject knifePrefab;

        [Header("Settings")]
        [SerializeField]
        private float rotationTime;
        [SerializeField]
        private float rotationZ; // How much we'll torate around Z axis

        public List<Level> levels;

        [HideInInspector]
        public List<Knife> knifes;

        private int levelIndex;

        private void Start()
        {
            if (isBoss)
            {
                // Do something
            }

            RotateWheel();
            levelIndex = Random.Range(0, levels.Count);

            if (levels[levelIndex].appleChance > Random.value)
            {
                SpawnApple();
            }

            SpawnKnifes();
        }

        private void SpawnApple()
        {
            foreach (float appleAngle in levels[levelIndex].appleAngleFromWheel)
            {
                GameObject appleTmp = Instantiate(applePrefab);
                appleTmp.transform.SetParent(transform);

                SetRotateFromWHeel(transform, appleTmp.transform, appleAngle, 0.25f, 0f);
                appleTmp.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            }
        }

        private void SpawnKnifes()
        {
            foreach (float knifeAngle in levels[levelIndex].knifeAngleFromWheel)
            {
                GameObject knifeTmp = Instantiate(knifePrefab);
                knifeTmp.transform.SetParent(transform);

                SetRotateFromWHeel(transform, knifeTmp.transform, knifeAngle, 0.20f, 180f);
                knifeTmp.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            }
        }

        private void RotateWheel()
        {
            Mathf.LerpAngle(transform.localEulerAngles.z, transform.localEulerAngles.z + rotationZ, rotationTime);
        }

        public void SetRotateFromWHeel(Transform wheel, Transform objectToPlace, float angle, float spaceFromObject, float objectRotation)
        {
            Vector2 offset = new Vector2(Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad))
                * (wheel.GetComponent<CircleCollider2D>().radius + spaceFromObject);
            objectToPlace.localPosition = (Vector2)wheel.localPosition + offset;
            objectToPlace.localRotation = Quaternion.Euler(0, 0, -angle + objectRotation);
        }

        public void KnifeHit(Knife knife)
        {
            knife.rigidBody.isKinematic = true;
            knife.rigidBody.velocity = Vector2.zero;
            knife.transform.SetParent(transform);
            knife.IsHit = true;

            knifes.Add(knife);

            if (knifes.Count >= availableKnifes)
            {
                // Go to next level
            }

            // Score ++
        }

        // Cal by GameManager, for complete level
        public void DestoryKnife()
        {
            foreach (var knife in knifes)
            {
                Destroy(knife.gameObject);
            }

            Destroy(gameObject);
        }
    }
}