
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int health = 3;
    public static int lives = 3;
    public static int score = 0;

    private float flickerTime = 0f;
    public float flickerDuration = 0.1f;

    private SpriteRenderer sr;
    
    // We will make the LevelManager a private reference
    private LevelManager LevelManager;

    public bool isImmune = false;
    private float immunityTime = 0f;
    public float immunityDuration = 1.5f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        // Get the LevelManager only once
        LevelManager = FindObjectOfType<LevelManager>();
        if (LevelManager == null)
        {
             Debug.LogError("LevelManagerScript not found! Respawn will fail.");
        }
    }

    void Update()
    {
        if (isImmune)
        {
            SpriteFlicker();
            immunityTime += Time.deltaTime;
            if (immunityTime >= immunityDuration)
            {
                isImmune = false;
                sr.enabled = true;
                immunityTime = 0f; // Reset immunity time upon exiting immunity
            }
        }
    }

    void SpriteFlicker()
    {
        if (flickerTime < flickerDuration)
        {
            flickerTime += Time.deltaTime;
        }
        else // flickerTime >= flickerDuration
        {
            sr.enabled = !(sr.enabled);
            flickerTime = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isImmune)
        {
            health -= damage;
            health = Mathf.Max(health, 0); // Health cannot go below 0

            if (lives > 0 && health == 0)
            {
                // 1. Tell the manager to respawn the player (at the checkpoint)
                if (LevelManager != null)
                {
                    LevelManager.RespawnPlayer();
                }
                
                // 2. Reset health and decrease a life
                health = 3;
                lives--;
            }
            else if (lives == 0 && health == 0)
            {
                Debug.Log("Gameover");
                // You might want to load a Game Over scene here instead of destroying the player immediately
                // Example: SceneManager.LoadScene("GameOverScene");
                Destroy(this.gameObject);
            }

            Debug.Log("Player Health:" + health.ToString());
            Debug.Log("Player Lives:" + lives.ToString());
            
            // ACTIVATE IMMUNITY ONLY IF DAMAGE WAS TAKEN
            isImmune = true;
            immunityTime = 0f;
        }
    }
}
