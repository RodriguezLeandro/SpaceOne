using UnityEngine;

public class BossAttackScript01 : BossAttackScript
{
    public GameObject attack01Prefab;
    public float attack01Speed = -2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ExecuteAttack() 
    {
        // Instantiate the fireball prefab at the fire point's position and rotation
        GameObject attack01 = Instantiate(attack01Prefab, transform.position, Quaternion.Euler(0, 0, 90));

        // Get the fireball's Rigidbody component
        Rigidbody2D rb = attack01.GetComponent<Rigidbody2D>();

        // Set the velocity of the fireball to move upwards
        rb.velocity = transform.up * attack01Speed;

        // Destroy the fireball when it goes out of the screen
        Destroy(attack01, 5f); // Adjust the time according to your needs
    }
}
