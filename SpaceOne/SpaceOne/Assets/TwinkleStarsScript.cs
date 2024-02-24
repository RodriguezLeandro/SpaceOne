using UnityEngine;

public class TwinkleStarsScript : MonoBehaviour
{
    public float minAlpha = 0.2f; // Minimum alpha value
    public float maxAlpha = 1f; // Maximum alpha value
    public float twinkleSpeed = 1f; // Speed of twinkle

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the new alpha value based on time
        float alpha = Mathf.Lerp(minAlpha, maxAlpha, Mathf.PingPong(Time.time * twinkleSpeed, 1f));

        // Set the alpha value of the sprite renderer
        Color color = spriteRenderer.color;
        color.a = alpha;
        spriteRenderer.color = color;
    }
}
