using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoGhostEnemy : FlipEnemyController
{
    
    
   // Make sure this matches the damage you want the electric platform to inflict.
    // Since your health is 3, 1 damage is a good starting point.
    public int damageAmount = 1; 

    // Use OnTriggerStay2D instead of OnTriggerEnter2D for continuous damage hazards.
    // This allows the platform to damage the player immediately upon contact, 
    // and then the player's immunity frames will prevent rapid, instant death.
    private void OnTriggerStay2D(Collider2D other)
    {
        // We assume the player has the "Player" tag
        if (other.CompareTag("Player")) 
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            
            if (playerStats != null)
            {
                // The PlayerStats script handles the 'isImmune' check and damage application.
                playerStats.TakeDamage(damageAmount);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
