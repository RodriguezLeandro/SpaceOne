using UnityEngine;

public class rotateLoadingScript : MonoBehaviour
{

    public float rotationSpeed = -90f; // Adjust the rotation speed as needed

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
