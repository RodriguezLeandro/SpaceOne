using UnityEngine;

public class ShieldCollisionScript : MonoBehaviour
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
        if (collision.gameObject.layer == LayerMask.NameToLayer("EnemySkill"))
        {
            Destroy(collision.gameObject);
        }
    }
}
