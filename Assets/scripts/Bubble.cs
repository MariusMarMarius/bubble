using UnityEngine;

public class Bubble : MonoBehaviour
{
    private string spritePath = "glossy bubbles/img/"; // 图片路径
    public int nowBubble;

    public GameplayColor color; 

    private CircleCollider2D circleCollider;




    public float[] speedOptions = { 2.0f, 5.0f, 10.0f, 20.0f }; // 固定的速度选项
    private float speed;           // 当前速度

    public float destroyX = -15f;  // 超出这个位置销毁

    private void Start()
    {
        speed = speedOptions[Random.Range(0, speedOptions.Length)];
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    public void Setup(GameplayColor c, float s)
    {
        circleCollider = GetComponent<CircleCollider2D>();
        AssignColor(c);
        SetSize(s);
    }

    

    void AssignColor(GameplayColor c)
    {
        string fullPath = spritePath + c.ToString();

        Sprite newSprite = Resources.Load<Sprite>(fullPath);
        if (newSprite != null)
        {
            GetComponent<SpriteRenderer>().sprite = newSprite;
        }
        else
        {
            Debug.LogWarning($"Obstacle: 图片加载失败！路径: {fullPath}");
        }
    }

    void SetSize(float size)
    {
        transform.localScale = new Vector2(size, size); // 设置随机缩放
        circleCollider.radius = 1.22f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector2 pushDirection = (collision.transform.position - transform.position).normalized;

            collision.GetComponent<playerController>().bubbleKnock(pushDirection, 5f);
            //new effect
            SpawnSplashEffect();
            GameManager.Instance.IncreaseScore(5);
            Destroy(gameObject); // Zerstört die Bubble
        }
    }
    //Bubble splash effect
    void SpawnSplashEffect()
    {
        // 从 Resources 目录加载图片并创建 Sprite
        Sprite splashSprite = Resources.Load<Sprite>("splash");
        if (splashSprite != null)
        {
            GameObject splashEffect = new GameObject("BubbleSplash");
            SpriteRenderer renderer = splashEffect.AddComponent<SpriteRenderer>();
            renderer.sprite = splashSprite;

            splashEffect.transform.position = transform.position; // 设置位置

            // 让 splashEffect 的大小与 Obstacle 的大小一致
            splashEffect.transform.localScale = transform.localScale/2;


            Destroy(splashEffect, 2f); // 2 秒后销毁
        }
        else
        {
            Debug.LogWarning("Splash sprite not found in Resources folder!");
        }
        
    }


}
