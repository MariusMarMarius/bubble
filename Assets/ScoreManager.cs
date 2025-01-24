using UnityEngine;
using TMPro;  // 引入 TextMeshPro 命名空间

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;   // 用来显示分数的 TextMeshPro 组件

    void Start()
    {
        // 初始化显示的分数
        UpdateScoreText();
    }

    void Update()
    {
        // 更新显示的分数
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        // 从 GameManager 获取当前的分数
        scoreText.text = "Score: " + GameManager.Instance.score;
    }
}
