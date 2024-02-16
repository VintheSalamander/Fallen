using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float ySpeed = -10f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float yMovement = ySpeed * Time.fixedDeltaTime;
        Vector3 movement = new Vector3(0f, yMovement, 0f) * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }
}
