using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 20f;
    public float ySpeed = -10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float yMovement = ySpeed * Time.deltaTime;
        Vector3 movement = new Vector3(horizontalInput, yMovement, verticalInput) * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }
}

