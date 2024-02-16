using UnityEngine;

public class MainShipRotation : MonoBehaviour
{

    public float rotationSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        float rotationAmount = scrollInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward, rotationAmount);
    }
}
