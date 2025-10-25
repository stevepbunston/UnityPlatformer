using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float speed = 2f;          // Movement speed (units per second)
    [SerializeField] private float pauseTime = 0.5f;    // Pause duration at each end

    [Header("Movement Range")]
    [SerializeField] private float leftX = 2f;          // Left boundary
    [SerializeField] private float rightX = 16f;        // Right boundary (18 - 2 simplified)

    private Vector3 targetPosition;

    private void Start()
    {
        targetPosition = new Vector3(rightX, transform.position.y, transform.position.z);
        StartCoroutine(MovePlatform());
    }

    private IEnumerator MovePlatform()
    {
        while (true)
        {
            // Move toward target position
            while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    targetPosition,
                    speed * Time.deltaTime
                );
                yield return null;
            }

            // Snap exactly to target and pause
            transform.position = targetPosition;
            yield return new WaitForSeconds(pauseTime);

            // Switch direction
            targetPosition = (Mathf.Approximately(targetPosition.x, rightX))
                ? new Vector3(leftX, transform.position.y, transform.position.z)
                : new Vector3(rightX, transform.position.y, transform.position.z);
        }
    }
}
