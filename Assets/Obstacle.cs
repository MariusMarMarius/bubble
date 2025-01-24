using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private string imagePath = "glossy bubbles/img/"; // 图片路径
    private int minIndex = 1;
    private int maxIndex = 16;
    public int nowBubble;

    void Start()
    {
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
        float randomSize = Random.Range(1.0f, 2.0f); // 设定大小范围
        transform.localScale = new Vector3(randomSize, randomSize, 1f); // 设置随机缩放
    }
}
