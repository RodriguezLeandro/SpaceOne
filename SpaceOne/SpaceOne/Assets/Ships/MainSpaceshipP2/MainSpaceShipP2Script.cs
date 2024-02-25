using System.Collections;
using UnityEngine;

public class MainSpaceShipP2Script : MonoBehaviour
{
    public GameObject fireballPrefab; // Assign the fireball prefab in the Inspector
    public GameObject shieldPrefab; // Assign the shield prefab in the Inspector
    public GameObject fenixAttackPrefab; // Assign the new shield prefab in the Inspector
    public float fireballSpeed = 5f; // Adjust the speed of the fireball

    public float attackCooldown = 10f; // Time between attacks in seconds
    private bool canAttack = true; // Flag to track if the player can attack

    // Start is called before the first frame update
    void Start()
    {
        shieldPrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad2) && !shieldPrefab.activeSelf)
        {
            ShootFireball();
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            GameObject secondEnemy = GameObject.Find("EnemySpaceshipV2");

            if (secondEnemy != null)
            {
                shieldPrefab.SetActive(true);
            }
            if (secondEnemy == null && canAttack)
            {
                ShootFenixAttack();

                // Start the cooldown timer
                StartCoroutine(StartCooldown());
            }
        }
    }

    void ShootFireball()
    {
        // Instantiate the fireball prefab at the fire point's position and rotation
        GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);

        fireball.SetActive(true);

        // Get the fireball's Rigidbody component
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();

        // Set the velocity of the fireball to move upwards
        rb.velocity = transform.up * fireballSpeed;

        // Destroy the fireball when it goes out of the screen
        Destroy(fireball, 5f); // Adjust the time according to your needs
    }

    void ShootFenixAttack()
    {
        // Instantiate the fireball prefab at the fire point's position and rotation
        GameObject fenixAttack = Instantiate(fenixAttackPrefab, transform.position, Quaternion.identity);

        fenixAttack.SetActive(true);

        // Get the fireball's Rigidbody component
        Rigidbody2D rb = fenixAttack.GetComponent<Rigidbody2D>();

        // Set the velocity of the fireball to move upwards
        rb.velocity = transform.up * fireballSpeed;

        // Destroy the fireball when it goes out of the screen
        Destroy(fenixAttack, 5f); // Adjust the time according to your needs
    }

    IEnumerator StartCooldown()
    {
        // Disable the ability to attack
        canAttack = false;

        // Wait for the specified cooldown duration
        yield return new WaitForSeconds(attackCooldown);

        // Enable the ability to attack again after the cooldown
        canAttack = true;
    }
}
