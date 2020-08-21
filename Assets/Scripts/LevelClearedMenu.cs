using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelClearedMenu : MonoBehaviour
{
    public bool isCleared = false;

    public GameObject levelClearMenu;
    public GameObject player;

    // level finish distance different for levels
    private float clearDistance;

    private Scene currentScene;
    private string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        if (sceneName == "Tutorial")
        {
            clearDistance = 390;
        } else
        {
            clearDistance = 500;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distance = player.GetComponent<Transform>().position.x;
        float height = player.GetComponent<Transform>().position.y;

        if (distance > clearDistance) {
            isCleared = true;
            if (height > 8)
            {
                displayMenu();
            }
        }
    }

    public void NextLevel()
    {
        if (sceneName == "Tutorial")
        {
            SceneManager.LoadScene("Level1");
        } else if (sceneName == "Level1")
        {
            SceneManager.LoadScene("Level2");
        } else if (sceneName == "Level2")
        {
            SceneManager.LoadScene("Level3");
        } else if (sceneName == "Level3")
        {
            SceneManager.LoadScene("Level4");
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void displayMenu()
    {
        levelClearMenu.SetActive(true);
    }
}
