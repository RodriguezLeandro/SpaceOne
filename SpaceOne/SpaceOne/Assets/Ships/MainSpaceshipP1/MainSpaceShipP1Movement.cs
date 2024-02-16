using UnityEngine;

public class MainSpaceshipP1Movement : MonoBehaviour
{

    public float moveSpeed = 200f;

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

        if (Input.GetKey(KeyCode.W))
        {
            verticalInput = 10f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            verticalInput = -10f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 10f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -10f;
        }

        rigidBody2D.AddForce(new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime);

        GameObject parentObject = transform.parent.gameObject;

        // Find a child GameObject by name relative to the parent GameObject
        GameObject lifeIndicator = parentObject.transform.Find("MainSpaceshipP1LifeIndicator").gameObject;

        if (lifeIndicator != null) 
        {
            if (lifeIndicator.transform.childCount == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
