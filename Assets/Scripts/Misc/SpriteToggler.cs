using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeHitClone.Misc
{
    public class SpriteToggler : MonoBehaviour
    {
        [SerializeField]
        private GameObject spriteOn;
        [SerializeField]
        private GameObject spriteOff;

        public void SetEnableSprite(bool enable)
        {
            if (enable)
            {
                spriteOn.SetActive(true);
                spriteOff.SetActive(false);
            }
            else
            {
                spriteOn.SetActive(false);
                spriteOff.SetActive(true);
            }
        }
    }
}