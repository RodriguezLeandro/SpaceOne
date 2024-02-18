using UnityEngine;

public class EnemySpaceshipCollisions : MonoBehaviour
{
    public float lifeCapacity = 3f;
    public float enemiesDestroyed = 0f;
    public float endEnemiesDestroyedQuantity = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesDestroyed == endEnemiesDestroyedQuantity)
        {
            Destroy(gameObject);

            updateMainSpaceshipSprites();
        }
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
                updateEnemyDestroyed();
                Destroy(gameObject);
            }
            lifeCapacity--;
            if (lifeCapacity == 0f) 
            {
                updateEnemyDestroyed();
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

    private void updateEnemyDestroyed() 
    {
        GameObject spaceships = GameObject.Find("Spaceships");

        Transform mainEnemySpaceshipTransform = spaceships.transform.Find("EnemySpaceship");

        if (mainEnemySpaceshipTransform != null)
        {
            GameObject mainEnemySpaceship = spaceships.transform.Find("EnemySpaceship").gameObject;
            mainEnemySpaceship.GetComponent<EnemySpaceshipCollisions>().enemiesDestroyed++;
        }
    }

    private void updateMainSpaceshipSprites() 
    {
        GameObject mainSpaceship01 = GameObject.Find("MainSpaceshipP1_0").gameObject;
        GameObject mainSpaceship02 = GameObject.Find("MainSpaceshipP2_0").gameObject;
        Sprite newSprite = mainSpaceship01.GetComponent<SpriteTransformScript>().level2TransformSprite;
        Sprite newSprite2 = mainSpaceship02.GetComponent<SpriteTransformScript>().level2TransformSprite;

        // Get the Sprite Renderer component attached to player gameObject
        SpriteRenderer spriteRenderer = mainSpaceship01.GetComponent<SpriteRenderer>();
        SpriteRenderer spriteRenderer2 = mainSpaceship02.GetComponent<SpriteRenderer>();

        if (spriteRenderer != null && newSprite != null)
        {
            // Assign the new sprite to the Sprite Renderer component
            mainSpaceship01.GetComponent<SpriteRenderer>().sprite = newSprite;
        }

        if (spriteRenderer2 != null && newSprite2 != null)
        {
            // Assign the new sprite to the Sprite Renderer component
            mainSpaceship02.GetComponent<SpriteRenderer>().sprite = newSprite2;
        }
    }
}
