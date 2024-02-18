using UnityEngine;

public class MessageSwitcherScript : MonoBehaviour
{
    public Sprite[] sprites; // Array of sprites

    // Start is called before the first frame update
    void Start()
    {
        // Randomly select an index
        int randomIndex = Random.Range(0, sprites.Length);

        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[randomIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
