using System.Collections;
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
    public int HP = 3;
    public GameObject explosion;
    public HealthBar healthBar;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        healthBar.SetHealth(1f);
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

    public void Impact(Collision coll){
        HP -= 1;
        if(HP > 0){
            if(HP == 2){
                healthBar.SetHealth(0.791f);
            }else if(HP == 1){
                healthBar.SetHealth(0.59f);
            }
            ContactPoint[] contacts = new ContactPoint[10];
            int numContacts = coll.GetContacts(contacts);
            GameObject explosionInstance = Instantiate(explosion, contacts[Random.Range(0, numContacts - 1)].point, Quaternion.identity);
            explosionInstance.transform.localScale *= 3;
            StartCoroutine(DestroyExpPS(explosionInstance));
        }
        if(HP == 0){
            Explode(coll);
        }
    }

    void Explode(Collision coll){
        ContactPoint[] contacts = new ContactPoint[10];
        int numContacts = coll.GetContacts(contacts);
        healthBar.SetHealth(0.372f);
        GameObject explosionInstance = Instantiate(explosion, contacts[Random.Range(0, numContacts - 1)].point, Quaternion.identity);
        explosionInstance.transform.localScale *= 13;
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision coll){
        if(coll.gameObject.CompareTag("End")){
            Explode(coll);
        }
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

    IEnumerator DestroyExpPS(GameObject explosion){
        ParticleSystem expPS = explosion.GetComponent<ParticleSystem>();
        yield return new WaitForSeconds(expPS.main.duration);
        Destroy(explosion   );
    }
}
