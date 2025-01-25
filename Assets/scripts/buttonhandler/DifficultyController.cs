using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifficultyController : MonoBehaviour
{
    public TextMeshProUGUI difficultyBoard;
    public Button buttonDifficultyUp;
    public Button buttonDifficultyDown;
    public Button startButton;

    private int difficulty = 1;
    private int minDifficulty = 1;
    private int maxDifficulty = 10;

    void Start()
    {
        UpdateDifficultyText();
        buttonDifficultyUp.onClick.AddListener(IncreaseDifficulty);
        buttonDifficultyDown.onClick.AddListener(DecreaseDifficulty);
        startButton.onClick.AddListener(StartGame);
    }

    void UpdateDifficultyText()
    {
        difficultyBoard.text = "Difficulty: " + difficulty.ToString();
    }

    void IncreaseDifficulty()
    {
        if (difficulty < maxDifficulty)
        {
            difficulty++;
            UpdateDifficultyText();
        }
    }

    void DecreaseDifficulty()
    {
        if (difficulty > minDifficulty)
        {
            difficulty--;
            UpdateDifficultyText();
        }
    }

    void StartGame()
    {
        // **保存难度到 PlayerPrefs**
        PlayerPrefs.SetInt("SelectedDifficulty", difficulty);
        PlayerPrefs.Save();

        // 切换到游戏场景
        SceneManager.LoadScene("newscene");
    }
}
