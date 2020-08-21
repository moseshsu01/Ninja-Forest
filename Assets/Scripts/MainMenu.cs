using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject music0;
    public GameObject music1;

    public GameObject mainMenu;
    public GameObject LevelSelect;

    public GameObject menuMusic;

    public void musicOFF()
    {
        music0.SetActive(true);
        music1.SetActive(false);
        menuMusic.GetComponent<AudioSource>().mute = true;
    }

    public void musicON()
    {
        music0.SetActive(false);
        music1.SetActive(true);
        menuMusic.GetComponent<AudioSource>().mute = false;
    }

    public void LoadLevels()
    {
        mainMenu.SetActive(false);
        LevelSelect.SetActive(true);
    }

    public void LoadEndlessMode()
    {
        SceneManager.LoadScene("Endless");
    }

    public void Back()
    {
        mainMenu.SetActive(true);
        LevelSelect.SetActive(false);
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void LoadLevel4()
    {
        SceneManager.LoadScene("Level4");
    }

}
