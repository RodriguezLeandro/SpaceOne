using UnityEngine;

public class MainSpaceShipP2Collision : MonoBehaviour
{
    public GameObject spawnPoint;

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
        /* Check if the collision involves the enemyLayer and the EnemySkillLayer*/
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy") 
            || collision.gameObject.layer == LayerMask.NameToLayer("EnemySkill")
            || collision.gameObject.layer == LayerMask.NameToLayer("FinalBossSkill"))
        {
            if (collision.gameObject.CompareTag("EnemySpaceship") 
                || collision.gameObject.CompareTag("EnemySkill")
                || collision.gameObject.CompareTag("FinalBossLaser01")
                || collision.gameObject.CompareTag("FinalBossLaser02"))
            {
                // Access the GameObject that collided with the "PlayerLayer" collider
                GameObject player = gameObject;

                // Now you can do whatever you want with the player GameObject
                // For example, you can get its Rigidbody2D component, its Transform, etc.
                Transform playerTransform = player.transform;

                Rigidbody2D playerRigidbody = gameObject.GetComponent<Rigidbody2D>();

                // Check if the Rigidbody component is not null
                if (playerRigidbody != null)
                {
                    // Access the player's Rigidbody here
                    // You can do whatever you want with the Rigidbody
                    playerRigidbody.rotation = 0f;
                }

                // Reset position to (0, 0, 0)
                playerTransform.position = spawnPoint.transform.position;

                // Reset rotation to identity (no rotation)
                playerTransform.rotation = Quaternion.identity;

                // Destroy enemy spaceship only if not finalBossAttack
                if (!(collision.gameObject.CompareTag("FinalBossLaser01") || collision.gameObject.CompareTag("FinalBossLaser02")))
                {
                    Destroy(collision.gameObject);
                }

                GameObject parentObject = transform.parent.gameObject;

                // Find a child GameObject by name relative to the parent GameObject
                GameObject lifeIndicator = parentObject.transform.Find("MainSpaceshipP2LifeIndicator").gameObject;

                if (lifeIndicator != null)
                {
                    GameObject nextLife = lifeIndicator.transform.GetChild(0).gameObject;

                    if (nextLife != null)
                    {
                        Destroy(nextLife);
                    }
                }
            }

            if (collision.gameObject.CompareTag("MainSpaceship01"))
            {
                Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
            }
        }
    }
}
