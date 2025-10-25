using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private int maxHealth = 1; // set 1 for regular enemies, higher (e.g., 15) for bosses
    private int currentHealth;

    [Header("Hit Flash Settings")]
    [SerializeField] private Color flashColor = Color.red;
    [SerializeField] private float flashDuration = 0.1f;

    [Header("Is Boss?")]
    [SerializeField] private bool isBoss = false; //  check this in the Inspector for your boss

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    private void Awake()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
            originalColor = spriteRenderer.color;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Flash effect on hit
        if (spriteRenderer != null)
            StartCoroutine(FlashSprite());

        // Check for death
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isBoss)
        {
            //Trigger win before destroying boss
            PlayerMovement player = FindObjectOfType<PlayerMovement>();
            if (player != null)
            {
                player.Win();
            }
        }

        // Optional: add particles, sound, animation, etc. before destroy
        Destroy(gameObject);
    }

    private IEnumerator FlashSprite()
    {
        if (spriteRenderer == null)
            yield break;

        spriteRenderer.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
    }
}

