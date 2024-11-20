using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombHandler : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    public AudioClip audioClip;
    public float Speed = 2f;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        Vector3 targetPosition = new Vector3(spriteRenderer.transform.position.x, -15, spriteRenderer.transform.position.z); // Mục tiêu Y = -6
        spriteRenderer.transform.position = Vector3.MoveTowards(spriteRenderer.transform.position, targetPosition, Speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.name;
        if (player == "RightPlayer" || player == "LeftPlayer")
        {
            spriteRenderer.enabled = false;
            boxCollider.enabled = false;
            AudioSource.PlayClipAtPoint(audioClip, gameObject.transform.position);
        }
    }
}