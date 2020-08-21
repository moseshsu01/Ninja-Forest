using UnityEngine;

public class MenuRunner : MonoBehaviour
{
    public float movingSpeed = 6f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(movingSpeed, 0);
    }

}
