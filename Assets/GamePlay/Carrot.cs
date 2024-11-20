using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    public AudioClip audioClip;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite=ButtonManager.Instance.listFruits[ButtonManager.Instance.LoadSelectedSprite()].imgFruit;
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.name;
        if (player == "RightPlayer" || player == "LeftPlayer")
        {
            spriteRenderer.enabled = false;
            boxCollider.enabled = false;
            //AudioSource.PlayClipAtPoint(audioClip, gameObject.transform.position);
        }
    }
}