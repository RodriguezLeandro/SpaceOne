using UnityEngine;

public class MainSpaceshipP2Movement : MonoBehaviour
{

    public float speed = 200f; // Adjust speed as needed

    private Rigidbody2D rigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = 0f;
        float horizontalInput = 0f;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            verticalInput = 10f;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            verticalInput = -10f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput = 10f;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput = -10f;
        }

        rigidBody2D.AddForce(new Vector3(horizontalInput, verticalInput, 0f) * speed * Time.deltaTime);

        GameObject parentObject = transform.parent.gameObject;

        // Find a child GameObject by name relative to the parent GameObject
        GameObject lifeIndicator = parentObject.transform.Find("MainSpaceshipP2LifeIndicator").gameObject;

        if (lifeIndicator != null)
        {
            if (lifeIndicator.transform.childCount == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
