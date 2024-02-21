using UnityEngine;

public class MainSpaceShipSkills : MonoBehaviour
{

    public GameObject fireballPrefab; // Assign the fireball prefab in the Inspector
    public GameObject laserPrefab; // Assign the laser prefab in the Inspector
    public GameObject newLaserPrefab; // Assign the laser prefab in the Inspector
    public float laserDuration = 5f; // Assing the laser duration
    public float fireballSpeed = 5f; // Adjust the speed of the fireball

    // Start is called before the first frame update
    void Start()
    {
        laserPrefab.SetActive(false);
        newLaserPrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Check for J button click
        if (Input.GetKeyDown(KeyCode.J))
        {
            ShootFireball();
        }

        // Check for K button click
        if (Input.GetKeyDown(KeyCode.K))
        {
            GameObject secondEnemy = GameObject.Find("EnemySpaceshipV2");

            if (secondEnemy != null)
            {
                GameObject setActiveGameObject = laserPrefab.GetComponent<setActive>().gameObject;
                setActiveGameObject.SetActive(true);
            }

            if (secondEnemy == null)
            {
                GameObject setActiveGameObject = newLaserPrefab.GetComponent<setActive>().gameObject;
                setActiveGameObject.SetActive(true);
            }
        }
    }

    void ShootFireball()
    {
        // Instantiate the fireball prefab at the fire point's position and rotation
        GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);

        // Get the fireball's Rigidbody component
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();

        // Set the velocity of the fireball to move upwards
        rb.velocity = transform.up * fireballSpeed;

        // Destroy the fireball when it goes out of the screen
        Destroy(fireball, 5f); // Adjust the time according to your needs
    }
}
