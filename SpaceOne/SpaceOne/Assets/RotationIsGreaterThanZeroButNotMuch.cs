using UnityEngine;

public class RotationIsGreaterThanZeroButNotMuch : MonoBehaviour
{
    public float maxRotationAngle = 10f; // Maximum rotation angle allowed

    private Quaternion initialRotation;

    // Start is called before the first frame update
    void Start()
    {
        // Store the initial rotation of the object
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the difference between the current rotation and the initial rotation
        Quaternion deltaRotation = transform.rotation * Quaternion.Inverse(initialRotation);

        // Convert the delta rotation to Euler angles
        Vector3 eulerDelta = deltaRotation.eulerAngles;

        // Limit the rotation angles within the specified range
        eulerDelta.x = Mathf.Clamp(eulerDelta.x, -maxRotationAngle, maxRotationAngle);
        eulerDelta.y = Mathf.Clamp(eulerDelta.y, -maxRotationAngle, maxRotationAngle);
        eulerDelta.z = Mathf.Clamp(eulerDelta.z, -maxRotationAngle, maxRotationAngle);

        // Convert the Euler angles back to a Quaternion rotation
        Quaternion limitedRotation = Quaternion.Euler(eulerDelta);

        // Apply the limited rotation to the object
        transform.rotation = initialRotation * limitedRotation;
    }
}
