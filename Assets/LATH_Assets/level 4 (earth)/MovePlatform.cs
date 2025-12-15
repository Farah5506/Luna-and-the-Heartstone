using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    // The start and end positions defined by empty GameObjects
    public Transform startPoint;
    public Transform endPoint;

    // How fast the platform moves (e.g., 2.0f)
    public float moveSpeed = 2f; 
    
    // How long the platform pauses at each end (e.g., 1.0f)
    public float pauseTime = 1f; 

    // Private variables for tracking movement
    private Vector3 nextPosition;
    private float waitTimer;

    void Start()
    {
        // 1. Initialize the next position to the start point
        nextPosition = startPoint.position;
        
        // 2. Start the wait timer
        waitTimer = pauseTime;
        
        // Ensure the platform starts at the start point's position
        transform.position = startPoint.position;
    }

    void Update()
    {
        // Check if the platform has reached its target position
        if (transform.position == nextPosition)
        {
            // If we are at the target, start/continue the pause timer
            waitTimer -= Time.deltaTime; 

            // When the pause is over
            if (waitTimer <= 0)
            {
                // Toggle the next position (swap between start and end)
                if (nextPosition == startPoint.position)
                {
                    nextPosition = endPoint.position;
                }
                else
                {
                    nextPosition = startPoint.position;
                }
                // Reset the timer for the next pause
                waitTimer = pauseTime;
            }
        }
        
        // Move the platform towards the target position
        // This uses MoveTowards for precise, constant speed movement
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, moveSpeed * Time.deltaTime);
    }

    // This function ensures the player stays attached to the moving platform
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object has the "Player" tag
        if (collision.CompareTag("Player"))
        {
            // Make the platform the parent of the player's transform
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the object exiting is the "Player"
        if (collision.CompareTag("Player"))
        {
            // Un-parent the player when they jump off or leave
            collision.transform.SetParent(null);
        }
    }
}
