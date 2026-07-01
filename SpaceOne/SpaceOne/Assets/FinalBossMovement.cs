using UnityEngine;

public class FinalBossMovement : MonoBehaviour
{
    public float VerticalOffset = 2f;
    public float speed = 5f; // Speed of movement
    public float radius = 2f; // Radius of the circular movement

    private float StartPositionX;
    private float StartPositionY;

    private float angle = 0f; // Current angle in radians

    // Start is called before the first frame update
    void Start()
    {
        StartPositionX = transform.position.x;
        StartPositionY = transform.position.y;
    }

    void Update()
    {
        // Update the angle based on time and speed
        angle += speed * Time.deltaTime;

        // Calculate the new position in a circular path
        float x = StartPositionX + Mathf.Cos(angle) * radius;
        float y = StartPositionY + Mathf.Sin(angle) * radius + VerticalOffset;

        // Set the position of the boss ship
        transform.position = new Vector3(x, y, 0f);
    }
}
