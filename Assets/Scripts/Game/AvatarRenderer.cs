using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeHitClone.Game
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class AvatarRenderer : MonoBehaviour
    {
        protected SpriteRenderer spriteRenderer;

        protected void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void SetSprite(Sprite sprite)
        {
            spriteRenderer.sprite = sprite;
        }

        public void HideSprite()
        {
            spriteRenderer.enabled = false;
        }
    }
}