using UnityEngine;

public class RayCastingTeledirigedScript : MonoBehaviour
{

    // Reference to the ray GameObject
    public GameObject rayObject;

    // Reference to the player GameObject
    public GameObject player;

    // LineRenderer component for visualizing the ray
    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the LineRenderer component
        lineRenderer = rayObject.GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            // Add the LineRenderer component if it's not already attached
            lineRenderer = rayObject.AddComponent<LineRenderer>();
        }

        // Set up the LineRenderer properties
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        // Ensure the rayObject and player references are set
        if (rayObject != null && player != null)
        {
            // Calculate the direction from the ray's origin to the player's position
            Vector3 direction = player.transform.position - rayObject.transform.position;

            // Normalize the direction vector to ensure it has a length of 1
            direction.Normalize();

            // Cast a ray in the calculated direction
            RaycastHit hit;
            if (Physics.Raycast(rayObject.transform.position, direction, out hit))
            {
                // Set the LineRenderer positions to visualize the raycast
                lineRenderer.SetPosition(0, rayObject.transform.position);
                lineRenderer.SetPosition(1, hit.point);

                // Perform actions based on the ray hit
                Debug.Log("Ray hit: " + hit.collider.gameObject.name);
            }
            else
            {
                // If the raycast didn't hit anything, set the LineRenderer positions to extend to a maximum distance
                float maxDistance = 10f;
                lineRenderer.SetPosition(0, rayObject.transform.position);
                lineRenderer.SetPosition(1, rayObject.transform.position + direction * maxDistance);
            }
        }
    }
}
