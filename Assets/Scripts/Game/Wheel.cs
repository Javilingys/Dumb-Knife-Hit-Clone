using KnifeHitClone.Misc;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
    private WheelRenderer wheelRenderer;

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
    #endregion

    #region Private Methods
    private void SpawnApples()
    {
        if (wheelData.chanceOfAppleSpawn > Random.value)
        {
            Transform apple = Instantiate(applePrefab, appleParent);
            float wheelRadius = GetComponent<CircleCollider2D>().radius;
            float appleRadius = apple.gameObject.GetComponent<CircleCollider2D>().radius;

            float randomAngle = wheelData.anglesForAppleSpawn[Random.Range(0, wheelData.anglesForAppleSpawn.Length)];

            Vector2 offset = Utils.GetVectorFromAngle(randomAngle) * (wheelRadius + appleRadius);

            apple.localPosition = (Vector2)appleParent.localPosition + offset;
            apple.localRotation = Quaternion.Euler(0f, 0f, -randomAngle + 0f);
        }
    }

    // TODO: off control of this knifes
    private void SpawnKnifes()
    {
        HashSet<float> uniqueAngles = new HashSet<float>();
        float[] angles = new float[wheelData.knifesSpawnCount];

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
