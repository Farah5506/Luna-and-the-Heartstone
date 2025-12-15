using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // The GameObject of the Checkpoint the player last hit.
    public GameObject CurrentCheckpoint; 

    // Public reference to the Player's Transform (Assign this in the Inspector!)
    public Transform player; 

    void Start()
    {
        // Initial checkpoint is null, player starts at scene start position
        CurrentCheckpoint = null; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        if (CurrentCheckpoint != null)
        {
            // Use the public 'player' reference to set the position
            player.position = CurrentCheckpoint.transform.position;
            
            // Re-enable the player (in case the PlayerStats script temporarily disabled it)
            player.gameObject.SetActive(true); 
        }
        else
        {
            Debug.LogWarning("CurrentCheckpoint is null! Cannot respawn player.");
            // If no checkpoint, maybe just reload the scene (LevelManager)
        }
    }
}


