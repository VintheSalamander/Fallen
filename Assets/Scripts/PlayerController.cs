using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject submarine;
    public GameObject spaceship;
    public float moveSpeed = 20f;
    public float ySpeed = -10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        submarine.SetActive(true);
        spaceship.SetActive(false);
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

    public void ChangeShipToDeepSea(){
        submarine.SetActive(true);
        spaceship.SetActive(false);
    }

    public void ChangeShipToSpace(){
        submarine.SetActive(false);
        spaceship.SetActive(true);
    }
}
