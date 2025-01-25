using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private bool isGameOver = false;  // 标志游戏是否结束

    void Start()
    {
        UpdateScoreText();
    }

    void Update()
    {
        if (!isGameOver)  // 只有在游戏未结束时才更新分数
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
        isGameOver = true;  // 标记游戏结束
        scoreText.text = "Game Over";
    }
}
