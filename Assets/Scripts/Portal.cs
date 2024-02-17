using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public float startY;
    public GameModeController gameMode;
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
            Transform playerTransform = coll.transform;
            playerTransform.position = new Vector3(playerTransform.position.x, startY, playerTransform.position.z);
            gameMode.ChangeEnviroment();
            Debug.Log("Change");
        }
    }
}
