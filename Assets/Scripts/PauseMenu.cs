using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject gameMusic;
    public GameObject music1;
    public GameObject music0;
    public GameObject sound1;
    public GameObject sound0;

    public bool isPaused = false;

    public GameObject player;
    private StoryPlayer script;

    private void Start()
    {
        script = player.GetComponent<StoryPlayer>();
    }

    private void Update()
    {
        if (!script.isDying && (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.Escape))))
        {
            if (!isPaused)
            {
                Pause();
            } else
            {
                Resume();
            }
        }
    }

    public void musicOFF()
    {
        music0.SetActive(true);
        music1.SetActive(false);
        gameMusic.GetComponent<AudioSource>().mute = true;
    }

    public void musicON()
    {
        music0.SetActive(false);
        music1.SetActive(true);
        gameMusic.GetComponent<AudioSource>().mute = false;
    }

    public void soundOFF()
    {
        sound0.SetActive(true);
        sound1.SetActive(false);
        player.GetComponent<PlayerMovement>().muteSounds();
    }

    public void soundON()
    {
        sound0.SetActive(false);
        sound1.SetActive(true);
        player.GetComponent<PlayerMovement>().muteSounds();
    }

    private void Pause()
    {
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
        isPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        isPaused = false;
    }

    public void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
