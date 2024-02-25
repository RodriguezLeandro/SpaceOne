using UnityEngine;

public class AimToGameObject : MonoBehaviour
{
    // Reference to the player GameObject
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Ensure the player1 reference is set
        if (player != null)
        {
            // Calculate the direction vector from the current GameObject to Player 1's position
            Vector3 directionToPlayer1 = player.transform.position - transform.position;

            // Create a ray starting from the current GameObject's position and aiming towards Player 1's position
            Ray ray = new Ray(transform.position, directionToPlayer1);

            // Draw the ray in the Scene view for debugging purposes
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);

            // Perform actions based on the raycast (e.g., object detection)
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // If the ray hits something, you can perform actions here
                Debug.Log("Ray hit: " + hit.collider.gameObject.name);
            }
        }
    }
}
