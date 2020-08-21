using UnityEngine;

public class FollowDummy : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject player; 

    // Start is called before the first frame update
    void Start()
    {
        MenuRunner playerScript = player.GetComponent<MenuRunner>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(playerScript.movingSpeed, 0);
    }
}
