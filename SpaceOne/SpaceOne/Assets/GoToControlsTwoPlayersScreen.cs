using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToControlsTwoPlayersScreen : MonoBehaviour
{

    // Sound to be played when a collision occurs
    public AudioClip collisionSound;

    // AudioSource component for playing the collision sound
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure an AudioSource component is attached to the GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Add an AudioSource component if one is not attached
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the collision sound to the AudioSource
        audioSource.clip = collisionSound;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Get the mouse position in the world coordinates
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Perform a 2D raycast to check if the mouse is over the square
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            // If the raycast hits the square
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                // Play the collision sound
                audioSource.Play();

                Invoke("ChangeScene", 1.8f);
            }
        }
    }

    private void ChangeScene()
    {
        // Switch to the specified scene
        SceneManager.LoadScene("Controls2Players");
    }
}
