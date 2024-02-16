using UnityEngine;

public class mainSpaceshipAndBoundariesCollisions : MonoBehaviour
{
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
        /* Check if the collision involves the PlayerLayer and the EnemyLayer*/
        if (collision.gameObject.layer == LayerMask.NameToLayer("Spaceship"))
        {
            Debug.Log("Collision with player done");

            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("Player has collided");
                // Access the GameObject that collided with the "PlayerLayer" collider
                GameObject player = collision.gameObject;

                // Now you can do whatever you want with the player GameObject
                // For example, you can get its Rigidbody2D component, its Transform, etc.
                Rigidbody2D playerRigidbody = player.GetComponent<Rigidbody2D>();
                Transform playerTransform = player.transform;

                // Reset position to (0, 0, 0)
                playerTransform.position = Vector3.zero;

                // Reset rotation to identity (no rotation)
                playerTransform.rotation = Quaternion.identity;

                // Reset scale to (1, 1, 1) for uniform scaling
                playerTransform.localScale = Vector3.one;
            }
        }
    }
}
