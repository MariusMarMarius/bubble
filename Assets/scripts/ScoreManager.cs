using UnityEngine;
using TMPro;  // ���� TextMeshPro �����ռ�

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;   // ������ʾ������ TextMeshPro ���

    void Start()
    {
        // ��ʼ����ʾ�ķ���
        UpdateScoreText();
    }

    void Update()
    {
        // ������ʾ�ķ���
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        // �� GameManager ��ȡ��ǰ�ķ���
        scoreText.text = "Score: " + GameManager.Instance.score;
    }
}
