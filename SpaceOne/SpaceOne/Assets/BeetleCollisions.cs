using UnityEngine;

public class BeetleCollisions : MonoBehaviour
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
        /* Check if the collision involves the playerSkillLayer */
        if (collision.gameObject.layer == LayerMask.NameToLayer("PlayerSkill"))
        {
            // Check to not destroy laser in case of collision of enemy with laser rigidBody2d
            if (!collision.gameObject.CompareTag("LightLaser"))
            {
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
