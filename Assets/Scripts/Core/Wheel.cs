using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeHitClone.Core
{
    public class Wheel : MonoBehaviour
    {
        private void Update()
        {
            transform.Rotate(new Vector3(0f, 0f, 50f * Time.deltaTime));
        }
    }
}