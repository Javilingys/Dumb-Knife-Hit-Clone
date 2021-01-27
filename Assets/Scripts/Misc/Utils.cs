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

        // Inverse function of GerVectorFromAngle
        public static float GetAngleFromVector(Vector3 vector)
        {
            float radians = Mathf.Atan2(vector.y, vector.x);
            float degress = radians * Mathf.Rad2Deg;
            return degress;
        }

        public static Vector3 GetVectorFromAngle(float angle)
        {
            return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad));
        }

        public static void Shuffle<T>(this System.Random rng, T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }
}