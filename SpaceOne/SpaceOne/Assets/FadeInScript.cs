using System.Collections;
using UnityEngine;

public class FadeInScript : MonoBehaviour
{

    public float fadeInDuration = 2f; // Duration of the fade-in effect in seconds

    private Renderer objectRenderer; // Reference to the renderer component
    private Color originalColor; // Original color of the object

    // Start is called before the first frame update
    void Start()
    {
        //TODO: Set active in false to only see boss when the moment is key.
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        // Get the Renderer component of the GameObject
        objectRenderer = GetComponent<Renderer>();

        // Store the original color of the object
        originalColor = objectRenderer.material.color;

        // Set the alpha value of the original color to 0 (fully transparent)
        originalColor.a = 0f;

        // Apply the modified color to the object
        objectRenderer.material.color = originalColor;

        // Start the coroutine to fade in the object
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        // Initialize the alpha value
        float alpha = 0f;

        // Loop until the alpha value reaches 1 (fully opaque)
        while (alpha < 1f)
        {
            // Increment the alpha value based on time
            alpha += Time.deltaTime / fadeInDuration;

            // Set the alpha value of the object's color
            originalColor.a = Mathf.Clamp01(alpha);
            objectRenderer.material.color = originalColor;

            // Wait for the end of the frame
            yield return null;
        }
    }
}
