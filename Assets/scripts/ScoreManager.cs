using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private bool isGameOver = false;  // ��־��Ϸ�Ƿ����

    void Start()
    {
        UpdateScoreText();
    }

    void Update()
    {
        if (!isGameOver)  // ֻ������Ϸδ����ʱ�Ÿ��·���
        {
            UpdateScoreText();
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + GameManager.Instance.score;
    }

    public void SetGameOverScore()
    {
        isGameOver = true;  // �����Ϸ����
        scoreText.text = "Game Over";
    }
}
