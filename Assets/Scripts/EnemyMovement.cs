using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float xSpeed = 1f;
    public float xMagnitude = 1f;
    public float zSpeed = 1f;
    public float zMagnitude = 1f;
    public float ySpeed = 1f; 
    private Rigidbody rb;
    private int ranMov = -1;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ranMov = Random.Range(0, 3);
    }

    void FixedUpdate()
    {
        Vector3 movement = Vector3.zero;
        if(ranMov == 0){
            float horizontalOffset = Mathf.Sin(Time.time * xSpeed) * xMagnitude;
            movement = Vector3.right * horizontalOffset;
        }else if(ranMov == 1){
            float verticalOffset = Mathf.Sin(Time.time * zSpeed) * zMagnitude;
            movement = Vector3.forward * verticalOffset;
        }
        

        float yMovement = ySpeed * Time.fixedDeltaTime;
        movement += new Vector3(0f, yMovement, 0f) * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }
}
