using UnityEngine;

public class TutorialHandler : MonoBehaviour
{
    public GameObject jumpingText;
    public GameObject glidingText;
    public GameObject slidingText;
    public GameObject pauseText;
    public GameObject goodLuckText;

    public GameObject gameOverMenu;
    private GameOverStory gameOverScript;

    public GameObject player;
    private float player_pos;

    private void Start()
    {
        gameOverScript = gameOverMenu.GetComponent<GameOverStory>();
    }

    // Update is called once per frame
    void Update()
    {

        player_pos = player.GetComponent<Transform>().position.x;

        if (!gameOverScript.gameOver)
        {
            if (5.5f < player_pos && player_pos < 65.5f)
            {
                jumpingText.SetActive(true);
            } else if (95.5f < player_pos && player_pos < 155.5f)
            {
                glidingText.SetActive(true);
            } else if (185.5f < player_pos && player_pos < 245.5f)
            {
                slidingText.SetActive(true);
            } else if (270.5f < player_pos && player_pos < 300.5f)
            {
                pauseText.SetActive(true);
            } else if (325.5f < player_pos && player_pos < 360.5f) {
                goodLuckText.SetActive(true);
            } else 
            {
                jumpingText.SetActive(false);
                glidingText.SetActive(false);
                slidingText.SetActive(false);
                pauseText.SetActive(false);
                goodLuckText.SetActive(false);
            }
        }
    }
}
