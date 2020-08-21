using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverStory : MonoBehaviour
{
    public GameObject gameOverMenu;

    public GameObject player;

    private StoryPlayer script;
    public bool gameOver;

    private void Start()
    {
        script = player.GetComponent<StoryPlayer>();

    }

    private void Update()
    {
        if (script.isDying || script.fallenBehind())
        {
            DisplayMenu();
            gameOver = true;
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void DisplayMenu()
    {
        gameOverMenu.SetActive(true);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        gameOver = false;
    }
}
