using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenu;

    public GameObject player;
    public Text scoreText;

    private PlayerMovement script;

    private bool isDisplayed;

    private void Start()
    {
        script = player.GetComponent<PlayerMovement>();
        isDisplayed = false;
    }

    private void Update()
    {
        if (!isDisplayed && (script.isDying || script.fallenBehind()))
        {
            DisplayMenu();
            isDisplayed = true;
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void DisplayMenu()
    {
        gameOverMenu.SetActive(true);
        scoreText.text = "SCORE: " + ((int)Time.timeSinceLevelLoad).ToString();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
