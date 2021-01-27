using KnifeHitClone.Misc;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    [SerializeField]
    private WheelData wheelData; // TODO: set outside (delete SerializeField)

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


    private List<Knife> knifes;

    private void Awake()
    {
        knifes = new List<Knife>();
    }

    private void Start()
    {
        SpawnApples();
        SpawnKnifes();
    }

    // TODO: Change angle
    private void SpawnApples()
    {
        Transform apple = Instantiate(applePrefab, appleParent);
        float wheelRadius = GetComponent<CircleCollider2D>().radius;
        float appleRadius = apple.gameObject.GetComponent<CircleCollider2D>().radius;

        Vector2 offset = Utils.GetVectorFromAngle(90f) * (wheelRadius + appleRadius);

        apple.localPosition = (Vector2)appleParent.localPosition + offset;
        apple.localRotation = Quaternion.Euler(0f, 0f, -90f + 0f);
    }

    // TODO: off control of this knifes + change angles
    private void SpawnKnifes()
    {
        // TODO: change bounds of loop
        for (int i = 0; i < 1; i++)
        {
            Transform knife = Instantiate(knifePrefab, knifeParent).transform;
            BoxCollider2D knifeCollider = knife.gameObject.GetComponent<BoxCollider2D>();
            float wheelRadius = GetComponent<CircleCollider2D>().radius;
            float halfHeight = knifeCollider.size.y / 2;

            Vector2 offset = Utils.GetVectorFromAngle(45f) * (wheelRadius + halfHeight);

            knife.localPosition = (Vector2)appleParent.localPosition + offset + new Vector2(knifeCollider.offset.x, knifeCollider.offset.y);
            knife.localRotation = Quaternion.Euler(0f, 0f, -45f + 180f);

            knife.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }

    private void Update()
    {
        RotateWheel();
    }

    private void RotateWheel()
    {
        transform.Rotate(new Vector3(0, 0, wheelData.speed * Time.deltaTime));
    }
}
