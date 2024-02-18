using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject mainEnemyPrefab; // Reference to the enemy spaceship prefab
    public GameObject secondaryEnemyPrefab; // Reference to the secondary enemy spaceship prefab
    public Transform[] spawnPoints; // Array of spawn points where enemies can appear

    public float spawnInterval = 3f; // Time interval between enemy spawns
    private float timer = 0f; // Timer to track spawn intervals

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {

        // Find a GameObject by name
        GameObject spaceships = GameObject.Find("Spaceships");

        Transform mainEnemySpaceship = spaceships.transform.Find("EnemySpaceship");

        Transform secondaryEnemySpaceship = spaceships.transform.Find("EnemySpaceshipV2");

        if (mainEnemySpaceship != null) 
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
                GameObject enemyCloned = Instantiate(mainEnemyPrefab, spawnPoints[spawnPointIndex].position, Quaternion.identity);

                EnemySpaceShipSkills enemySpaceshipSkills = enemyCloned.GetComponent<EnemySpaceShipSkills>();

                if (enemySpaceshipSkills != null)
                {
                    enemySpaceshipSkills.isOriginal = false;
                }
            }
        }

        if (mainEnemySpaceship == null && secondaryEnemySpaceship != null) 
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
                GameObject enemyCloned = Instantiate(secondaryEnemyPrefab, spawnPoints[spawnPointIndex].position, Quaternion.identity);

                EnemySpaceShipSkills enemySpaceshipSkills = enemyCloned.GetComponent<EnemySpaceShipSkills>();

                if (enemySpaceshipSkills != null)
                {
                    enemySpaceshipSkills.isOriginal = false;
                }
            }
        }
    }
}
