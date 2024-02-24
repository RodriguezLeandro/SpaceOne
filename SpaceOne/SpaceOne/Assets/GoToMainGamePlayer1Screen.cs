using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainGamePlayer1Screen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Start the coroutine to change the scene after a delay
        StartCoroutine(ChangeSceneAfterDelay());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator ChangeSceneAfterDelay()
    {
        // Wait for 10 seconds
        yield return new WaitForSeconds(10f);

        // Load the new scene
        SceneManager.LoadScene("MainGamePlayer1Scene");
    }
}
