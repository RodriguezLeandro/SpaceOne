using UnityEngine;

public class BossAttackScript02 : BossAttackScript
{

    public GameObject attack02Prefab;
    public float attack02Speed = -2f;

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
        GameObject attack02 = Instantiate(attack02Prefab, transform.position, Quaternion.Euler(0, 0, 90));

        // Get the fireball's Rigidbody component
        Rigidbody2D rb = attack02.GetComponent<Rigidbody2D>();

        // Set the velocity of the fireball to move upwards
        rb.velocity = transform.up * attack02Speed;

        // Destroy the fireball when it goes out of the screen
        Destroy(attack02, 5f); // Adjust the time according to your needs
    }
}
