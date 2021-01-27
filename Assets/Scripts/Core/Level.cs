using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeHitClone.Core
{
    [System.Serializable]
    public class Level
    {
        [Range(0, 1)]
        public float appleChance;

        public List<float> appleAngleFromWheel = new List<float>();
        public List<float> knifeAngleFromWheel = new List<float>();
    }
}