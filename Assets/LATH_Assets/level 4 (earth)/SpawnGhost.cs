using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGhost : GhostEnemy
{
    public Transform enemy;
    public Transform spawnPoint;
    public SpriteRenderer sr;

    private bool hasSpawned = false; // <-- ADD THIS

    void RespawnEnemy(){
        if (hasSpawned) return; // <-- ADD THIS (prevents duplicates)

        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        hasSpawned = true; // <-- ADD THIS (lock spawn)
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            RespawnEnemy();
        }
    }

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }
}

