using UnityEngine;

public class MainSpaceShipSkills : MonoBehaviour
{

    public GameObject fireballPrefab; // Assign the fireball prefab in the Inspector
    public GameObject laserPrefab; // Assign the laser prefab in the Inspector
    public GameObject newLaser01Prefab; // Assign the laser prefab in the Inspector
    public float laserDuration = 5f; // Assing the laser duration
    public float fireballSpeed = 5f; // Adjust the speed of the fireball
    public float newLaserSpeed = 5f; // Adjust the speed of the fireball

    // Start is called before the first frame update
    void Start()
    {
        laserPrefab.SetActive(false);
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
                ShootNewLaser();
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

    void ShootNewLaser()
    {
        // Instantiate the fireball prefab at the fire point's position and rotation
        GameObject newLaser01 = Instantiate(newLaser01Prefab, transform.position + new Vector3(-0.3f, 0f, 0f), Quaternion.identity);

        // Get the fireball's Rigidbody component
        Rigidbody2D rb = newLaser01.GetComponent<Rigidbody2D>();

        // Set the velocity of the fireball to move upwards
        rb.velocity = transform.up * newLaserSpeed;

        // Destroy the fireball when it goes out of the screen
        Destroy(newLaser01, 5f); // Adjust the time according to your needs

        // Instantiate the fireball prefab at the fire point's position and rotation
        GameObject newLaser02 = Instantiate(newLaser01Prefab, transform.position + new Vector3(0.3f, 0f, 0f), Quaternion.identity);

        // Get the fireball's Rigidbody component
        Rigidbody2D rb2 = newLaser02.GetComponent<Rigidbody2D>();

        // Set the velocity of the fireball to move upwards
        rb2.velocity = transform.up * newLaserSpeed;

        // Destroy the fireball when it goes out of the screen
        Destroy(newLaser02, 5f); // Adjust the time according to your needs
    }
}
