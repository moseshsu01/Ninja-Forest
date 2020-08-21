using UnityEngine;

public class StoryPlayer : MonoBehaviour
{
    private bool isRunning, isJumping, isGliding, isLanding, isSliding, isClimbing = false;
    public bool isDying = false;
    private bool duringGame = false; // since we're displaying the menu before game start
    public float movingSpeed = 6f;
    public float jumpForce = 18f;
    private bool isGrounded = false;

    public AudioSource jump;
    public AudioSource land;
    public AudioSource smash;
    public AudioSource splat;

    float fJumpPressedRemember = 0;
    [SerializeField]
    float fJumpPressedRememberTime = 0.2f;

    Rigidbody2D rb;

    public Animator anim;
    public GameObject dummy;

    public GameObject levelClearMenu;
    private LevelClearedMenu levelClearScript;
    private bool isCleared = false;

    // Start is called before the first frame update
    void Start()
    {

        duringGame = true;
        isRunning = false;
        anim.SetBool("isRunning", false);
        isLanding = true;
        anim.SetBool("isLanding", true);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(movingSpeed, 0);

        levelClearScript = levelClearMenu.GetComponent<LevelClearedMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (levelClearScript.isCleared)
        {
            duringGame = false;
            isCleared = true;
        }

        if (isCleared)
        {
            isRunning = false;
            anim.SetBool("isRunning", false);
            isClimbing = true;
            anim.SetBool("isClimbing", true);
            rb.velocity = new Vector2(0, 4f);
            dummy.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        }
        else if (duringGame)
        {
            fJumpPressedRemember -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                fJumpPressedRemember = fJumpPressedRememberTime;
            }

            if (fJumpPressedRemember > 0 && isGrounded && !isJumping)
            {
                isJumping = true;
                anim.SetBool("isJumping", true);
                isRunning = false;
                anim.SetBool("isRunning", false);
                isSliding = false;
                anim.SetBool("isSliding", false);
                Jump();
            }
            else if (Input.GetKey(KeyCode.UpArrow) && fJumpPressedRemember != fJumpPressedRememberTime && ((isJumping && rb.velocity.y <= 0) || isLanding))
            {
                isJumping = false;
                anim.SetBool("isJumping", false);
                isLanding = false;
                anim.SetBool("isLanding", false);
                isGliding = true;
                anim.SetBool("isGliding", true);
                Physics2D.gravity = new Vector2(0, -1f);
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.12f);
            }
            else if (!Input.GetKey(KeyCode.UpArrow) && isGliding)
            {
                isGliding = false;
                anim.SetBool("isGliding", false);
                Physics2D.gravity = new Vector2(0, -9.81f);
                isLanding = true;
                anim.SetBool("isLanding", true);
            }
            else if (Input.GetKey(KeyCode.DownArrow) && isRunning && isGrounded)
            {
                isSliding = true;
                anim.SetBool("isSliding", true);
                isRunning = false;
                anim.SetBool("isRunning", false);
            }
            else if (!Input.GetKey(KeyCode.DownArrow) && isSliding)
            {
                isSliding = false;
                anim.SetBool("isSliding", false);
                isRunning = true;
                anim.SetBool("isRunning", true);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && rb.velocity.y <= 0 && (isJumping || isLanding))
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 2f);
            }
        }
    }

    private void Jump()
    {
        jump.Play();
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
        rb.velocity = movement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground") && !isDying)
        {
            if (Mathf.Abs(rb.velocity.y) < 0.1)
            {
                land.Play();

                isSliding = false;
                anim.SetBool("isSliding", false);
                isLanding = false;
                anim.SetBool("isLanding", false);
                isGliding = false;
                anim.SetBool("isGliding", false);
                Physics2D.gravity = new Vector2(0, -9.81f);
                isJumping = false;
                anim.SetBool("isJumping", false);
                isRunning = true;
                anim.SetBool("isRunning", true);

                isGrounded = true;
            }
            
            
        }
        else if (!isDying && (collision.gameObject.CompareTag("Sharp") || collision.gameObject.CompareTag("SharpSplat")))
        {
            if (collision.gameObject.CompareTag("SharpSplat"))
            {
                splat.Play();
            }
            else
            {
                smash.Play();
            }
            isRunning = isGliding = isJumping = isLanding = isSliding = false;
            anim.SetBool("isRunning", false);
            anim.SetBool("isGliding", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isLanding", false);
            anim.SetBool("isSliding", false);
            isDying = true;
            anim.SetBool("isDying", true);
            rb.velocity = new Vector2(0, rb.velocity.y);
            dummy.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            duringGame = false;
            Physics2D.gravity = new Vector2(0, -9.81f);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;

            if (!isJumping)
            {
                isRunning = false;
                anim.SetBool("isRunning", false);
                isSliding = false;
                anim.SetBool("isSliding", false);
                isLanding = true;
                anim.SetBool("isLanding", true);
            }
        }
    }

    public void muteSounds()
    {
        if (jump.mute)
        {
            jump.mute = false;
            land.mute = false;
            smash.mute = false;
            splat.mute = false;
        }
        else
        {
            jump.mute = true;
            land.mute = true;
            smash.mute = true;
            splat.mute = true;
        }
    }

    public bool fallenBehind()
    {
        return (dummy.GetComponent<Transform>().position.x - gameObject.GetComponent<Transform>().position.x > 5);
    }
}
