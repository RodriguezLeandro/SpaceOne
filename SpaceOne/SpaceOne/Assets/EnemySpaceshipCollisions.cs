using UnityEngine;

public class EnemySpaceshipCollisions : MonoBehaviour
{
    public float lifeCapacity = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        /* Check if the collision involves the playerSkillLayer */
        if (collision.gameObject.layer == LayerMask.NameToLayer("PlayerSkill"))
        {
            // Check to not destroy laser in case of collision of enemy with laser rigidBody2d
            if (!collision.gameObject.CompareTag("LightLaser")) 
            {
                Destroy(collision.gameObject);
            }
            // If collision is with light laser then the object is destroyed
            if (collision.gameObject.CompareTag("LightLaser"))
            {
                Destroy(gameObject);
            }
            lifeCapacity--;
            if (lifeCapacity == 0f) 
            {
                Destroy(gameObject);
            }
        }

        /* Smooth collision with boundaries */
        if (collision.gameObject.layer == LayerMask.NameToLayer("Boundaries"))
        {

            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();

            // Calculate the direction of bouncing (reverse the horizontal velocity)
            float newVelocityX = -rb.velocity.x;

            rb.AddForce(new Vector3(newVelocityX, rb.velocity.y, 0f) * 10f);
        }
    }
}
