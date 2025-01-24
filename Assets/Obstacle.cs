using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private string imagePath = "glossy bubbles/img/"; // ��Դ·������� Resources �ļ��У�
    private int minIndex = 1;  // ��СͼƬ���
    private int maxIndex = 16; // ���ͼƬ���
    public int nowBubble;

    void Start()
    {
        AssignRandomSprite();

        // **�����С��1.0f ~ 2.0f**
        float randomSize = Random.Range(1.0f, 2.0f);
        transform.localScale = new Vector3(randomSize, randomSize, 1f);
    }


    void AssignRandomSprite()
    {
        // **���ѡ��һ��ͼƬ**
        int randomIndex = Random.Range(minIndex, maxIndex + 1);
        nowBubble = randomIndex;
        string fullPath = imagePath + randomIndex; // ����Ҫ�� .png ��׺

        // **���� PNG ��Ϊ Sprite**
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
}