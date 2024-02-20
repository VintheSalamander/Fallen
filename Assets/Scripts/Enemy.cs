using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision coll){
        if(coll.gameObject.CompareTag("Player")){
            coll.gameObject.GetComponent<PlayerController>().Impact(coll);
        }
    }
}
