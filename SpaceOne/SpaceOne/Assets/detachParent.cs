using UnityEngine;

public class detachParent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Detach the GameObject from its parent
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
