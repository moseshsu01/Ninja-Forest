using UnityEngine;

public class FollowDummyEndless : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject player;
    PlayerMovement playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(playerScript.movingSpeed, 0);
    }
}
