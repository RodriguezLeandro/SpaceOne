using UnityEngine;

public class fixPosition : MonoBehaviour
{
    private Vector3 initialPosition; // Store the initial position

    void Start()
    {
        // Store the initial position when the GameObject starts
        initialPosition = transform.position;
    }

    void Update()
    {
        // Reset the position to the initial position in each frame update
        transform.position = initialPosition;
    }
}
