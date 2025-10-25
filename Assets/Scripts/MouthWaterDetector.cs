using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthWaterDetector : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private int waterLayer;

    void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
        waterLayer = LayerMask.NameToLayer("Water");

        if (playerMovement == null)
        {
            Debug.LogError("MouthWaterDetector: No PlayerMovement script found on parent GameObject.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == waterLayer)
        {
            Debug.Log("Mouth entered water");
            playerMovement.SetMouthUnderwater(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == waterLayer)
        {
            Debug.Log("Mouth exited water");
            playerMovement.SetMouthUnderwater(false);
        }
    }
}
