using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float laserSpeed = 5f;
    Rigidbody2D myRigidbody;
    PlayerMovement player;
    float xSpeed;

    bool hasHit = false; //prevent multiple triggers

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * laserSpeed;
    }

    void Update()
    {
        myRigidbody.velocity = new Vector2(xSpeed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasHit) return; // already hit something, ignore

        hasHit = true; // mark as hit so it won’t damage again

        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(1); //subtract 1 health
            }
        }

        Destroy(gameObject); //always destroy immediately
    }
}

