using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab; // Reference to the enemy spaceship prefab
    public Transform[] spawnPoints; // Array of spawn points where enemies can appear

    public float spawnInterval = 3f; // Time interval between enemy spawns
    private float timer = 0f; // Timer to track spawn intervals

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        // Update the timer
        timer += Time.deltaTime;

        // Check if it's time to spawn a new enemy
        if (timer >= spawnInterval)
        {
            // Reset the timer
            timer = 0f;

            // Randomly select a spawn point index
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            // Instantiate an enemy at the selected spawn point
            GameObject enemyCloned = Instantiate(enemyPrefab, spawnPoints[spawnPointIndex].position, Quaternion.identity);

            EnemySpaceShipSkills enemySpaceshipSkills = enemyCloned.GetComponent<EnemySpaceShipSkills>();

            if (enemySpaceshipSkills != null)
            { 
                enemySpaceshipSkills.isOriginal = false;
            }
        }
    }
}
