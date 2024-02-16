using UnityEngine;

public class EnemySpaceshipMovement : MonoBehaviour
{

    public float speed = 5f; // Speed of movement
    public float sideMovementRange = 1f; // Range of movement to the sides

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        {
            // Move downwards
            transform.Translate(Vector3.down * speed * Time.deltaTime);

            // Move a little to the sides using Mathf.Sin for oscillating movement
            float sideMovement = sideMovementRange * Mathf.Sin(Time.time);
            transform.Translate(Vector3.right * sideMovement * Time.deltaTime);
        }
    }
}
