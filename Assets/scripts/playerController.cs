using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed = 5f;
    public float jumpPower;

    private bool isGrounded;


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
        


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jump(jumpPower);
            isGrounded = false;
        }
    }

    public void jump(float jumpForce)
    {
        rb.AddForce(new Vector2(0,jumpForce));
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
        isGrounded = true;
    }
}
