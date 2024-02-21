using UnityEngine;

public class FadeControllerScript : MonoBehaviour
{
    public Material material; // Reference to the material using the shader
    public string parameterName = "_FadeAmount"; // Name of the parameter in the shader

    public float fadeDuration = 2f; // Duration of the fade effect
    private float fadeAmount = 0f; // Current fade amount

    // Start is called before the first frame update
    void Start()
    {
        // Optional: Set initial fade amount
        fadeAmount = 0f;
        UpdateShaderParameter();
    }

    // Update is called once per frame
    void Update()
    {
        // Increment fade amount over time
        fadeAmount += Time.deltaTime / fadeDuration;

        // Clamp fade amount between 0 and 1
        fadeAmount = Mathf.Clamp01(fadeAmount);

        // Update shader parameter
        UpdateShaderParameter();
    }

    private void UpdateShaderParameter()
    {
            // Check if material and parameter name are valid
        if (material != null && !string.IsNullOrEmpty(parameterName))
        {
            // Apply fade amount to shader parameter
            material.SetFloat(parameterName, fadeAmount);
        }
    }
}
