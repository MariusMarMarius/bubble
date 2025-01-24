using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private string imagePath = "glossy bubbles/img/"; // 图片路径
    private int minIndex = 1;
    private int maxIndex = 16;
    public int nowBubble;


    private CircleCollider2D circleCollider;

    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();


        AssignRandomSprite();  // 分配随机图片
        SetRandomSize();       // 设置随机大小
    }

    // 随机分配图片
    void AssignRandomSprite()
    {
        int randomIndex = Random.Range(minIndex, maxIndex + 1);
        nowBubble = randomIndex;
        string fullPath = imagePath + randomIndex;

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

    // 随机设置障碍物的大小
    void SetRandomSize()
    {
        float randomSize = Random.Range(0.3f, 1.0f); // 设定大小范围
        transform.localScale = new Vector2(randomSize, randomSize); // 设置随机缩放
        //circleCollider.radius = transform.localScale.x *2;
        circleCollider.radius = 1.22f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector2 pushDirection = (collision.transform.position - transform.position).normalized;

            collision.GetComponent<playerController>().bubbleKnock(pushDirection, 5f);

            Destroy(gameObject); // Zerstört die Bubble
        }
    }
}
