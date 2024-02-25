using System;
using UnityEngine;

public class FinalBossCollisions : MonoBehaviour
{
    public GameObject beetle1Prefab;
    public GameObject beetle2Prefab;
    public ParticleSystem impactEffect; // Reference to the impact particle effect
    public float finalBossLives = 1000f;
    public Transform[] spawnPoints; // Array of spawn points where enemies can appear

    public float spawnInterval = 3f; // Time interval between enemy spawns
    private float timer = 0f; // Timer to track spawn intervals
    private Boolean spawnBeetles = false;

    private float finalBossLivesTotal;
    // Start is called before the first frame update
    void Start()
    {
        finalBossLivesTotal = finalBossLives;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnBeetles)
        {
            // Update the timer
            timer += Time.deltaTime;

            // Check if it's time to spawn a new enemy
            if (timer >= spawnInterval)
            {
                // Reset the timer
                timer = 0f;

                // Randomly select a spawn point index
                int spawnPointIndex = UnityEngine.Random.Range(0, spawnPoints.Length);

                int beetleToInstantiate = UnityEngine.Random.Range(0, 2);

                if (beetleToInstantiate == 0)
                {
                    // Instantiate an enemy at the selected spawn point
                    GameObject beetlePrefab01 = Instantiate(beetle1Prefab, spawnPoints[spawnPointIndex].position, Quaternion.identity);
                    beetlePrefab01.SetActive(true);
                }

                if (beetleToInstantiate == 1)
                {
                    // Instantiate an enemy at the selected spawn point
                    GameObject beetlePrefab02 = Instantiate(beetle2Prefab, spawnPoints[spawnPointIndex].position, Quaternion.identity);
                    beetlePrefab02.SetActive(true);
                }
            }
        }
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
            finalBossLives--;
        }

        if (finalBossLives == finalBossLivesTotal / 2)
        {
            transformFinalBossMidLife();
            spawnBeetles = true;
        }

        if (finalBossLives == finalBossLivesTotal / 4)
        {
            transformFinalBossLowLife();
        }

        if (finalBossLives == 0f)
        { 
                   
        }
    }

    private void transformFinalBossMidLife() 
    {
        GameObject finalBossSpaceship = GameObject.Find("FinalBossSpaceship");

        if (finalBossSpaceship != null)
        {
            Sprite newSprite = finalBossSpaceship.GetComponent<SpriteTransformScript>().level2TransformSprite;

            // Get the Sprite Renderer component attached to player gameObject
            SpriteRenderer spriteRenderer = finalBossSpaceship.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null && newSprite != null)
            {
                // Assign the new sprite to the Sprite Renderer component
                finalBossSpaceship.GetComponent<SpriteRenderer>().sprite = newSprite;
            }
        }
    }

    private void transformFinalBossLowLife()
    {
        GameObject finalBossSpaceship = GameObject.Find("FinalBossSpaceship");

        if (finalBossSpaceship != null)
        {
            Sprite newSprite = finalBossSpaceship.GetComponent<SpriteTransformScript>().level5TransformSprite;

            // Get the Sprite Renderer component attached to player gameObject
            SpriteRenderer spriteRenderer = finalBossSpaceship.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null && newSprite != null)
            {
                // Assign the new sprite to the Sprite Renderer component
                finalBossSpaceship.GetComponent<SpriteRenderer>().sprite = newSprite;
            }
        }
    }
}
