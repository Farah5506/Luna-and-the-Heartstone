using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int damage=1;

[HideInInspector]
public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr=GetComponent<SpriteRenderer>();
    }
    void FixedUpdate(){
        
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag=="Player"){
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
           
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
