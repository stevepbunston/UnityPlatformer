using UnityEngine;

public enum PowerUpType
{
    Snorkel,
    Shoes,
    Potion
}

public class PowerUp : MonoBehaviour
{
    [SerializeField] private PowerUpType powerUpType;
    [SerializeField] private float jumpMultiplier = 1.5f; // only for Shoes

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if (player == null) return;

        // Apply effect
        switch (powerUpType)
        {
            case PowerUpType.Snorkel:
                player.SetInfiniteBreath(true);
                break;
            case PowerUpType.Shoes:
                player.SetJumpMultiplier(jumpMultiplier);
                break;
            case PowerUpType.Potion:
                player.EnableLaserEyes(true);
                break;
        }

        // Destroy the power-up after pickup
        Destroy(gameObject);
    }
}
