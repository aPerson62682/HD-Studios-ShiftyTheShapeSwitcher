using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;
    public Transform respawnPoint;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public ParticleSystem dust;

    void Update()
    {

        if (DialogueManager.Instance.isDialogueActive)
        {
            horizontal = 0f;
            return;

        }


        horizontal = Input.GetAxisRaw("Horizontal");

        // Jump using Space (default Jump button), "W", or "Up Arrow"
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && IsGrounded())
        {
            SoundManager.Instance.PlaySound2D("Jump");
            dust.Play();
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
        }

        // Reduce jump height if key is released mid-air
        if ((Input.GetButtonUp("Jump") || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }

        Flip();
    }
    //private void Start()
    //{
    //    MusicManager.Instance.PlayMusic("MainTheme");

    //}
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;

            if (IsGrounded())
            {
                dust.Play();
            }

        }
    }
}