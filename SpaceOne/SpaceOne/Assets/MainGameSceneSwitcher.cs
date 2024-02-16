using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameSceneSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Find a GameObject by name
        GameObject spaceships = GameObject.Find("Spaceships");

        Transform spaceship01 = spaceships.transform.Find("MainSpaceshipP1_0");
        Transform spaceship02 = spaceships.transform.Find("MainSpaceshipP2_0");

        if (spaceship01 == null && spaceship02 == null)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
