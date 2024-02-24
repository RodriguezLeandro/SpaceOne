using UnityEngine;

public class FinalBossMovement : MonoBehaviour
{
    public float VerticalOffset = 2f;
    public float speed = 5f; // Speed of movement
    public float radius = 2f; // Radius of the circular movement

    private float angle = 0f; // Current angle in radians

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        // Update the angle based on time and speed
        angle += speed * Time.deltaTime;

        // Calculate the new position in a circular path
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius + VerticalOffset;

        // Set the position of the boss ship
        transform.position = new Vector3(x, y, 0f);
    }
}
