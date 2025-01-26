using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator ani;

    public float moveSpeed = 5f;
    public float jumpPower;

    public bool isGrounded;
    public bool canDoubleJump;
    


    public GameManager gameManager;

    public GameplayColor color;

    public int coins;


    float moveInput;



    public RuntimeAnimatorController classic;
    public RuntimeAnimatorController uwu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();

        ani.runtimeAnimatorController = uwu;
    }

    // Update is called once per frame
    void Update()
    {
        inputCheck();

        if (moveInput < 0)
        {
            Vector3 localScale = transform.localScale;
            localScale.x = -1; 
            transform.localScale  = localScale;
        }
        else if (moveInput > 0)
        {
            Vector3 localScale = transform.localScale;
            localScale.x = 1;
            transform.localScale = localScale;
        }
    }


    void inputCheck()
    {
        moveInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveInput, 0);

        
        if (moveInput > 0 && rb.linearVelocity.x < moveSpeed || moveInput < 0 && rb.linearVelocity.x > -moveSpeed)
        {
            rb.AddForce(movement * moveSpeed * Time.deltaTime * 2);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            jump(jumpPower);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            color = GameplayColor.PINK;
            ani.SetTrigger("pinkTrigger");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            color = GameplayColor.GREEN;
            ani.SetTrigger("greenTrigger");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            color = GameplayColor.ORANGE;
            ani.SetTrigger("orangeTrigger");
        }
    }

    public void jump(float jumpForce)
    {
        AudioClip jumpSound = Resources.Load<AudioClip>("voice/jump");
        if (!isGrounded && !canDoubleJump)
        {
            return;
        }
        if (!isGrounded)
        {
            canDoubleJump = false;
        }
        AudioSource audioSource = this.gameObject.AddComponent<AudioSource>();
        if (jumpSound != null)
        {
            audioSource.clip = jumpSound;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Splash sound not found in Resources/voice folder!");
        }
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        rb.AddForce(new Vector2(0, jumpForce));
    }

    public void bubbleKnock(Vector2 direction, float pushForce)
    {
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
            AudioClip landenSound = Resources.Load<AudioClip>("voice/landen");
            AudioSource audioSource = this.gameObject.AddComponent<AudioSource>();
            if (landenSound != null)
            {
                audioSource.clip = landenSound;
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("Splash sound not found in Resources/voice folder!");
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            Destroy(collision.gameObject);
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 1);
            Debug.Log("now coin is" + PlayerPrefs.GetInt("Coins"));
            
            coins++;
        }
    }
}
