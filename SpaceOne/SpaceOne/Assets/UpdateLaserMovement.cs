using UnityEngine;

public class UpdateLaserMovement : MonoBehaviour
{
    public float laserSpeed = 1.0f;
    public float delay = 3f; // Delay time before deactivating the object

    private Rigidbody2D rigidBody2D;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Set the velocity of the fireball to move upwards
        rigidBody2D.velocity = transform.up * laserSpeed;
    }

    void OnEnable()
    {
        // Get the fireball's Rigidbody component
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();

        Invoke("Deactivate", delay);
    }

    void Deactivate()
    {
        gameObject.SetActive(false); // Deactivate the GameObject
    }
}
