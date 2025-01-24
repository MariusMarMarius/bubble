using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 8f;

    private bool isGrounded;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Springen, wenn die Leertaste gedrückt wird und der Spieler am Boden ist
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jump(10);
            isGrounded = false;
        }
    }

    public void jump(int jumpForce)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
}
