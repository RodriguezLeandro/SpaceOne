using UnityEngine;

public class BossAttackController : MonoBehaviour
{

    // Define references to individual attack scripts
    public BossAttackScript[] attacks;

    // Define probabilities for each attack
    public float[] attackProbabilities;

    // Define min and max time interval between attacks
    public float minAttackInterval = 3f;
    public float maxAttackInterval = 5f;

    private float nextAttackTime; // Time to perform the next attack

    // Start is called before the first frame update
    void Start()
    {
        // Initialize nextAttackTime with a random time within the specified interval
        nextAttackTime = Time.time + Random.Range(minAttackInterval, maxAttackInterval);
    }

    // Update is called once per frame
    void Update()
    {
    // Check if it's time to perform the next attack
    if (Time.time >= nextAttackTime)
    {
        PerformRandomAttack();

        // Schedule the next attack by adding a random time interval to the current time
        nextAttackTime = Time.time + Random.Range(minAttackInterval, maxAttackInterval);
    }
}

    public void PerformRandomAttack()
    {
        // Ensure that the attacks array and probabilities array have the same length
        if (attacks.Length != attackProbabilities.Length)
        {
            Debug.LogError("The length of the attacks array and attackProbabilities array must be the same.");
            return;
        }

        // Generate a random value between 0 and 1
        float randomValue = Random.value;

        // Iterate through each attack and check if the random value falls within its probability range
        float cumulativeProbability = 0f;
        for (int i = 0; i < attacks.Length; i++)
        {
            cumulativeProbability += attackProbabilities[i];
            if (randomValue <= cumulativeProbability)
            {
                // Perform the selected attack
                attacks[i].ExecuteAttack();
                break;
            }
        }
    }
}
