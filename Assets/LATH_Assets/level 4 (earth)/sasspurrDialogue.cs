using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sasspurrDialogue : MonoBehaviour
{
    public Dialogue dialogueManager;

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag=="Player"){
            string[] dialogue= {
                "Luna: Umm..who are you?",
                "Sasspurr: Depends on who you want me to be, company.... or trouble?",
                "Luna: Would you please tell me which way I ought to go?",
                "Sasspurr: You have the same blood, you choose where you want to go",
                "Luna: Wha-?",
                "Sasspurr: Directions? Sweetheart I think it looks like you should decide what you want to be first",
            };
            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());

            Destroy(GetComponent<BoxCollider2D>(), 5f);
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
