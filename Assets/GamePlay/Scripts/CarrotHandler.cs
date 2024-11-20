using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarrotHandler : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    public AudioClip audioClip;

    public float fallSpeed = -2f;
    private Rigidbody2D rb;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rb.velocity = new Vector2(rb.velocity.x, fallSpeed);
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