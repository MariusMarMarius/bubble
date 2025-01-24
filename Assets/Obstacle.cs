using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private string imagePath = "glossy bubbles/img/";
    private int minIndex = 1;
    private int maxIndex = 16;
    public int nowBubble;

    private Rigidbody2D rb;
    public float minSpeed = 2.0f; // ��С�ٶ�
    public float maxSpeed = 5.0f; // ����ٶ�

    void Start()
    {
        AssignRandomSprite();
        AssignRandomSpeed();

        // 随机设置障碍物大小
        float randomSize = Random.Range(1.0f, 2.0f); // 随机范围为 1.0 ~ 2.0
        transform.localScale = new Vector3(randomSize, randomSize, 1f); // 设置大小
    }


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
            Debug.LogWarning($"Obstacle: ͼƬ����ʧ�ܣ�·��: {fullPath}");
        }
    }

    void AssignRandomSpeed()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogWarning("Obstacle: 没有 Rigidbody2D，无法设置速度！");
            return;
        }

        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        rb.linearVelocity = new Vector2(-randomSpeed, 0f); // 向左移动
    }
}
