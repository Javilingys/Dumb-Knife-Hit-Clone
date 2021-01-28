using KnifeHitClone.Data;
using KnifeHitClone.Misc;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace KnifeHitClone.Game
{
    public class Wheel : MonoBehaviour
    {
        private WheelData wheelData;

        [Header("Prefabs")]
        [SerializeField]
        private Knife knifePrefab;
        [SerializeField]
        private Transform applePrefab;

        [Header("Parents For Prefabs")]
        [SerializeField]
        private Transform knifeParent;
        [SerializeField]
        private Transform appleParent;

        [Header("Inner Components")]
        [SerializeField]
        private AvatarRenderer wheelRenderer;

        private List<Knife> knifes;

        #region Unity Methods
        private void Awake()
        {
            knifes = new List<Knife>();
        }

        private void Update()
        {
            RotateWheel();
        }
        #endregion

        #region Public Methods
        public void InitWheel(WheelData wheelData)
        {
            this.wheelData = wheelData;
            wheelRenderer.SetSprite(wheelData.wheelSprite);
            SpawnApples();
            SpawnKnifes();
        }

        public void KnifeHit(Knife knife)
        {
            knife.StopKnife();
            knife.transform.SetParent(knifeParent);
            knifes.Add(knife);
        } 
        #endregion

        #region Private Methods
        private void SpawnApples()
        {
            // if chance (0.25 for exmaple) of spawn greater than value from 0 to 1
            if (wheelData.chanceOfAppleSpawn > Random.value)
            {
                // Instantiate prefab
                Transform apple = Instantiate(applePrefab, appleParent);
                // Get a wheel radius from Circle Collider(!)
                float wheelRadius = GetComponent<CircleCollider2D>().radius;
                // Get an apple radius
                float appleRadius = apple.gameObject.GetComponent<CircleCollider2D>().radius;

                // Get random angle from array inside WheelData in Scriptable Object
                float randomAngle = wheelData.anglesForAppleSpawn[Random.Range(0, wheelData.anglesForAppleSpawn.Length)];

                // Offset from center to point of spawn
                Vector2 offset = Utils.GetVectorFromAngle(randomAngle) * (wheelRadius + appleRadius);

                // position
                apple.localPosition = (Vector2)appleParent.localPosition + offset;
                // rotation
                apple.localRotation = Quaternion.Euler(0f, 0f, -randomAngle + 0f);
            }
        }

        private void SpawnKnifes()
        {
            // Hashset for delete duplicates
            HashSet<float> uniqueAngles = new HashSet<float>();
            // final array which will contain unique random angles. Size = count of knifes which will spawn
            float[] angles = new float[wheelData.knifesSpawnCount];

            // Loop for get unique random angles
            for (int i = 0; i < wheelData.anglesForKnifeSpawn.Length; i++)
            {
                float randomAngle = wheelData.anglesForKnifeSpawn[Random.Range(0, wheelData.anglesForKnifeSpawn.Length)];
                uniqueAngles.Add(randomAngle);
                if (uniqueAngles.Count == wheelData.knifesSpawnCount)
                {
                    uniqueAngles.CopyTo(angles);
                    break;
                }
            }

            // instnatiate knifes
            for (int i = 0; i < wheelData.knifesSpawnCount; i++)
            {
                Knife knife = Instantiate(knifePrefab, knifeParent);
                BoxCollider2D knifeCollider = knife.gameObject.GetComponent<BoxCollider2D>();
                float wheelRadius = GetComponent<CircleCollider2D>().radius;
                float halfHeight = knifeCollider.size.y / 3;

                float angle = angles[i];

                Vector2 offset = Utils.GetVectorFromAngle(angle) * (wheelRadius + halfHeight);

                knife.transform.localPosition = (Vector2)appleParent.localPosition + offset;
                knife.transform.localRotation = Quaternion.Euler(0f, 0f, -angle + 180f);

                // disable behaviour of knife
                knife.IsHit = true;
                knifes.Add(knife);
                knife.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }
        }

        private void RotateWheel()
        {
            transform.Rotate(new Vector3(0, 0, wheelData.speed * Time.deltaTime));
        }
        #endregion
    }
}