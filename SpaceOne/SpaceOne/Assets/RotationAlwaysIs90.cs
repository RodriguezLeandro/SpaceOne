using UnityEngine;

public class RotationAlwaysIs90 : MonoBehaviour
{
    private Vector3 rotation = new Vector3(0, 0, 90);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Set the rotation to (0, 0, 90) in every frame
        transform.rotation = Quaternion.Euler(rotation);
    }
}
