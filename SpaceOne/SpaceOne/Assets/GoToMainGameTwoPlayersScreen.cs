using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainGameTwoPlayersScreen : MonoBehaviour
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

        // Load the scene asynchronously after the delay
        StartCoroutine(LoadSceneAsync("MainGameTwoPlayersScene"));
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        // Begin loading the scene asynchronously
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Wait until the load operation is done
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
