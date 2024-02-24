using UnityEngine;

public class deactivateFinalBoss : MonoBehaviour
{

    public GameObject targetObject;

    // Start is called before the first frame update
    void Start()
    {
        // Initially deactivate the targetObject
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
