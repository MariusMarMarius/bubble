using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score = 0;
    public float difficulty;
    public float scoreIncreaseRate = 1.0f;

    private float timeSinceLastScoreIncrease = 0f;


    public int coins;

    public float speed;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
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

    public void coinCollected()
    {
        coins++;
        Debug.Log(coins);
    }
}


public enum GameplayColor
{
    WHITE,
    ORANGE,
    GREEN,
    PINK
};