using UnityEngine;

public class RotationIsGreaterThanZeroButNotMuch : MonoBehaviour
{
    public float minRotationAngle = 0.01f; // Minimum rotation angle allowed

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current rotation angles of the object
        Vector3 currentRotation = transform.rotation.eulerAngles;

        // Clamp the rotation angles to ensure they remain slightly greater than zero
        float clampedXRotation = Mathf.Max(currentRotation.x, minRotationAngle);
        float clampedYRotation = Mathf.Max(currentRotation.y, minRotationAngle);
        float clampedZRotation = Mathf.Max(currentRotation.z, minRotationAngle);

        // Update the rotation of the object with the clamped values
        transform.rotation = Quaternion.Euler(clampedXRotation, clampedYRotation, clampedZRotation);
    }
}
