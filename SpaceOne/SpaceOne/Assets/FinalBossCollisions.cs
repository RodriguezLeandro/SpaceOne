using UnityEngine;

public class FinalBossCollisions : MonoBehaviour
{
    public ParticleSystem impactEffect; // Reference to the impact particle effect

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
        /* Check if the collision involves the playerSkill*/
        if (collision.gameObject.layer == LayerMask.NameToLayer("PlayerSkill"))
        {
            Destroy(collision.gameObject);

            if (impactEffect != null)
            {
                impactEffect.Play();
            }
        }
    }
}
