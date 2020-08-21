using UnityEngine;

public class FollwDummyStory : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject player;
    StoryPlayer playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<StoryPlayer>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(playerScript.movingSpeed, 0);
    }
}
