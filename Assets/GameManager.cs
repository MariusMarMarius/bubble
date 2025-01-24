using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // 单例模式，方便其他脚本访问
    public int score = 0;   // 当前分数
    public float difficulty = 1.0f; // 游戏难度（可以根据分数等调整）

    public float scoreIncreaseRate = 1.0f;  // 每秒增加的分数

    private float timeSinceLastScoreIncrease = 0f;  // 距离上次增加分数的时间

    void Awake()
    {
        // 如果 GameManager 实例为空，设置为当前对象
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // 确保只有一个 GameManager 存在
        }

        // 保持 GameManager 在场景切换时不被销毁
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        // 根据时间增加分数
        IncreaseScoreOverTime();

        // 根据分数或者其他因素来调整游戏难度
        UpdateDifficulty();
    }

    void IncreaseScoreOverTime()
    {
        timeSinceLastScoreIncrease += Time.deltaTime;  // 增加时间

        if (timeSinceLastScoreIncrease >= 1f)  // 每秒增加一次分数
        {
            score += 1;  // 增加分数
            timeSinceLastScoreIncrease = 0f;  // 重置计时
        }
    }

    void UpdateDifficulty()
    {
        if (score < 50)
        {
            difficulty = 1.0f;
        }
        else if (score < 100)
        {
            difficulty = 1.5f;
        }
        else
        {
            difficulty = 2.0f;
        }
    }

    public void IncreaseScore(int value)
    {
        score += value;
    }
}
