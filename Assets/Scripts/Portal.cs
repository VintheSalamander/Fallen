using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Portal : MonoBehaviour
{
    public float startPlayerY;
    public float[] xPosRange = new float[2];
    public float[] zPosRange = new float[2];
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
            playerTransform.position = new Vector3(playerTransform.position.x, startPlayerY, playerTransform.position.z);
            gameMode.ChangeEnviroment();
            ChangePortalPos();
        }
    }

    void ChangePortalPos(){
        float xPos = Random.Range(xPosRange[0], xPosRange[1]);
        float zPos = Random.Range(zPosRange[0], zPosRange[1]);
        transform.position = new Vector3(xPos, transform.position.y, zPos);
    }
}
