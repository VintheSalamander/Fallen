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

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float yMovement = ySpeed * Time.fixedDeltaTime;
        Vector3 movement = new Vector3(horizontalInput * moveSpeed, yMovement, verticalInput * moveSpeed) * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

    public void Explode(){
        Debug.Log("Player dead");
    }
}
