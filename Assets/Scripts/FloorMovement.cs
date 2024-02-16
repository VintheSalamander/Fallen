using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    public float ySpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float yMovement = ySpeed * Time.deltaTime;
        transform.Translate(Vector3.up * yMovement);
    }
}
