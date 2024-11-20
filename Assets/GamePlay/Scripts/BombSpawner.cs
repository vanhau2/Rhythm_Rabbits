using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject bombPrefab;
    public Transform spawnPoint;
    private float[] spawnPositionsX = { -0.5f, -1.8f, 0.8f, 2.1f };

    void Start()
    {
        StartCoroutine(SpawnBomb());
    }

    IEnumerator SpawnBomb()
    {
        yield return new WaitForSeconds(20);
        while (true)
        {
            float waitTime = Random.Range(8f, 15f);
            yield return new WaitForSeconds(waitTime);

            BoxCollider2D boxCollider2D = bombPrefab.GetComponent<BoxCollider2D>();
            SpriteRenderer spriteRenderer = bombPrefab.GetComponentInChildren<SpriteRenderer>();

            boxCollider2D.enabled = true;
            spriteRenderer.enabled = true;

            float randomX = spawnPositionsX[Random.Range(0, spawnPositionsX.Length)];

            Vector3 spawnPosition = new Vector3(randomX, spawnPoint.position.y, spawnPoint.position.z);

            Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
        }
    }
}