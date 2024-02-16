using UnityEngine;

public class setActive : MonoBehaviour
{
    public bool active = true;

    // Start is called before the first frame update
    void Start()
    {
        // Disable the GameObject this script is attached to
        gameObject.SetActive(active);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
