using UnityEngine;

public class InstantiateTransformOnEnable : MonoBehaviour
{

    // Reference to the target GameObject
    public GameObject gameObjectTransform;
    // Offset from the target GameObject
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update is called once per frame
    void OnEnable()
    {
        if (gameObjectTransform != null)
        {
            // Set the position of the current GameObject to match the position of the target GameObject
            transform.position = gameObjectTransform.transform.position + offset;

            // Reset rotation to identity (no rotation)
            transform.rotation = Quaternion.identity;
        }
    }
}
