using KnifeHitClone.Misc;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D)), RequireComponent(typeof(SpriteRenderer))]
public class Apple : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem appleParticle;

    private BoxCollider2D boxCollider2D;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.KNIFE))
        {
            boxCollider2D.enabled = false;
            spriteRenderer.enabled = false;

            appleParticle.Play();
            Destroy(gameObject, 2f);
        }
    }
}
