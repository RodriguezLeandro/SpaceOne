using System.Collections;
using UnityEngine;

public class BeetleSpaceshipSkills : MonoBehaviour
{
    public GameObject fireballBeetlePrefab; // Assign the fireball circle prefab in the Inspector
    public float fireballSpeed = 5f; // Adjust the speed of the fireball
    public float fireRate = 5f; // Time interval between fireball shots
    private float timer = 0f; // Timer to track the elapsed time

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Increment the timer by the time passed since the last frame
        timer += Time.deltaTime;

        // Check if the timer has reached the fire rate interval
        if (timer >= fireRate)
        {
             // Shoot fireball
             StartCoroutine(DelayActionFireballCircle(1f));
             // Reset the timer
             timer = 0f;
        }
    }

    IEnumerator DelayActionFireballCircle(float delayTime)
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(delayTime);

        // After the delay, set the action to false
        ShootFireballCircle();
    }

    void ShootFireballCircle()
    {
        // Instantiate the fireball prefab at the fire point's position and rotation
        GameObject fireball = Instantiate(fireballBeetlePrefab, transform.position, Quaternion.identity);

        // Get the fireball's Rigidbody component
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();

        // Set the velocity of the fireball to move upwards
        rb.velocity = new Vector2(0, -fireballSpeed);

        // Destroy the fireball when it goes out of the screen
        Destroy(fireball, 5f); // Adjust the time according to your needs
    }
}
