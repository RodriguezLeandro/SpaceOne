using UnityEngine;

public class rotationAlwaysIsZero : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Set the rotation to zero in every frame
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
