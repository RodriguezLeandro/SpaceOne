using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainGameScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
                // Switch to the specified scene
                SceneManager.LoadScene("PlayerSelectScreen");
            }
        }
    }
}
