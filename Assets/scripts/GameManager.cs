using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score = 0;
    public float difficulty;
    public float scoreIncreaseRate = 1.0f;

    private float timeSinceLastScoreIncrease = 0f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject); // 防止 GameManager 在切换场景时被销毁
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        // **在游戏场景加载时，从 PlayerPrefs 读取难度**
        difficulty = PlayerPrefs.GetInt("SelectedDifficulty", 1);
        Debug.Log("当前难度：" + difficulty);
    }

    void Update()
    {
        IncreaseScoreOverTime();
        UpdateDifficulty();
    }

    void IncreaseScoreOverTime()
    {
        timeSinceLastScoreIncrease += Time.deltaTime;

        if (timeSinceLastScoreIncrease >= 1f)
        {
            score += 1;
            timeSinceLastScoreIncrease = 0f;
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


public enum GameplayColor
{
    NONE,
    RED,
    BLUE,
    GREEN,
    YELLOW
};