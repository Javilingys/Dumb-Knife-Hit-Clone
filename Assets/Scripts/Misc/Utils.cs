using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeHitClone.Misc
{
    public static class Utils
    {
        public static Vector3 GetRandomDir()
        {
            return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        }

        public static float GetAngleFromVector(Vector3 vector)
        {
            float radians = Mathf.Atan2(vector.y, vector.x);
            float degress = radians * Mathf.Rad2Deg;
            return degress;
        }
    }
}