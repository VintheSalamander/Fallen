using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject submarine;
    public GameObject spaceship;
    public float moveSpeed = 20f;
    public float ySpeed = -500f;
    public float incrementYspeed= -50f;
    public float rotationSpeed = 10f;
    public float maxRotationAngle = 45f;
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

        float rotationAmount = horizontalInput * maxRotationAngle;

        float currentRotation;
        if(horizontalInput == 0 && transform.eulerAngles.y != 0){
            currentRotation = Mathf.Lerp(transform.eulerAngles.y, 0, rotationSpeed);
        }else{
            currentRotation = Mathf.Lerp(transform.eulerAngles.y, rotationAmount, rotationSpeed);
        }
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, currentRotation, transform.eulerAngles.z);
    }

    public void Explode(){
        Debug.Log("Player dead");
    }

    public void ChangeShipToDeepSea(){
        submarine.SetActive(true);
        spaceship.SetActive(false);
        IncreaseYSpeed();
    }

    public void ChangeShipToSpace(){
        submarine.SetActive(false);
        spaceship.SetActive(true);
        IncreaseYSpeed();
    }

    public void IncreaseYSpeed(){
        ySpeed += incrementYspeed;
    }
}
