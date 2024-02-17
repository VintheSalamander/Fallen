using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement: MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's transform
    public float yOffset = 5f; // Distance above the player to follow

    void Update()
    {
        if(playerTransform){
            transform.position = new Vector3(transform.position.x, playerTransform.position.y + yOffset, transform.position.z);
        }
    }
}
