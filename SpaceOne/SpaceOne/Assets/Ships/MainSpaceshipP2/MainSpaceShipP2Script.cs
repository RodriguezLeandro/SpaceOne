using UnityEngine;

public class MainSpaceShipP2Script : MonoBehaviour
{
    public GameObject fireballPrefab; // Assign the fireball prefab in the Inspector
    public GameObject shieldPrefab; // Assign the shield prefab in the Inspector
    public GameObject newShieldPrefab; // Assign the new shield prefab in the Inspector
    public float fireballSpeed = 5f; // Adjust the speed of the fireball

    // Start is called before the first frame update
    void Start()
    {
        shieldPrefab.SetActive(false);
        newShieldPrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad2) 
            && !shieldPrefab.GetComponent<setActive>().gameObject.activeInHierarchy 
            && !newShieldPrefab.GetComponent<setActive>().gameObject.activeInHierarchy)
        {
            ShootFireball();
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            GameObject secondEnemy = GameObject.Find("EnemySpaceshipV2");

            if (secondEnemy != null)
            {
                GameObject setActiveGameObject = shieldPrefab.GetComponent<setActive>().gameObject;
                setActiveGameObject.SetActive(true);
            }
            if (secondEnemy == null)
            {
                GameObject setActiveGameObject = newShieldPrefab.GetComponent<setActive>().gameObject;
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
