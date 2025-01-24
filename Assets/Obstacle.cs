using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private string imagePath = "glossy bubbles/img/"; // 资源路径（相对 Resources 文件夹）
    private int minIndex = 1;  // 最小图片编号
    private int maxIndex = 16; // 最大图片编号
    public int nowBubble;

    void Start()
    {
        AssignRandomSprite();

        // **随机大小：1.0f ~ 2.0f**
        float randomSize = Random.Range(1.0f, 2.0f);
        transform.localScale = new Vector3(randomSize, randomSize, 1f);
    }


    void AssignRandomSprite()
    {
        // **随机选择一个图片**
        int randomIndex = Random.Range(minIndex, maxIndex + 1);
        nowBubble = randomIndex;
        string fullPath = imagePath + randomIndex; // 不需要加 .png 后缀

        // **加载 PNG 作为 Sprite**
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
}