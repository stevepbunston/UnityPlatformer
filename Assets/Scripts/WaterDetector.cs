using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDetector : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private int waterLayer;

    void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
        waterLayer = LayerMask.NameToLayer("Water");

        if (playerMovement == null)
        {
            Debug.LogError("WaterDetector: No PlayerMovement script found on this or parent GameObject.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == waterLayer)
        {
            Debug.Log("Entered water");
            playerMovement.SetUnderwater(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == waterLayer)
        {
            Debug.Log("Exited water");
            playerMovement.SetUnderwater(false);
        }
    }
}
