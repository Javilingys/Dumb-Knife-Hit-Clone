using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeHitClone.Game
{
    public class Apple : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem appleParticle;
        [SerializeField]
        private AvatarRenderer appleRenderer;

        public void KnifeHit(Knife knife)
        {
            appleRenderer.HideSprite();
            appleParticle.Play();
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, appleParticle.main.duration);
        }
    }
}