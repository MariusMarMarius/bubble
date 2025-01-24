using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed = 5f;
    public float jumpPower;

    public bool isGrounded;
    public bool canDoubleJump;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputCheck();
    }


    void inputCheck()
    {
        float moveInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveInput, 0);

        
        if (moveInput > 0 && rb.linearVelocity.x < moveSpeed || moveInput < 0 && rb.linearVelocity.x > -moveSpeed)
        {
            rb.AddForce(movement * moveSpeed * Time.deltaTime * 2);
        }
        


        if (Input.GetKeyDown(KeyCode.Space) )
        {
            jump(jumpPower);
        }
    }

    public void jump(float jumpForce)
    {
        if (!isGrounded && !canDoubleJump)
        {
            return;
        }
        if (!isGrounded)
        {
            canDoubleJump = false;
        }
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(new Vector2(0, jumpForce));
    }

    public void bubbleKnock(Vector2 direction, float pushForce)
    {
        Debug.Log(direction);
        Debug.Log(pushForce);
        Debug.Log(direction * pushForce);
        rb.linearVelocity = Vector2.zero;
        
        rb.AddForce(direction * pushForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            if (collision.transform.position.y < transform.position.y)
            {
                isGrounded = true;
                canDoubleJump = true;
            }
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
        }
    }
}
