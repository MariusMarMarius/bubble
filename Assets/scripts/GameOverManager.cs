using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    // 引用 GameManager
    public ScoreManager scoreManager;
    public GameObject gameOverMenu;  // 游戏暂停时显示的菜单（可以是一个 UI 面板）
    private bool isGameOver = false;  // 用于判断当前是否结束
    public TextMeshProUGUI scoreText;
    public GameObject pauseButton;

    // 为了确保你设置的是 GameBoard 的 Collider2D
    public Collider2D gameBoardCollider;
    void Start()
    {
        // 初始时游戏没有暂停
        gameOverMenu.SetActive(false);  // 暂停菜单默认不可见
    }

    public void ToggleGameOver()
    {
        isGameOver = !isGameOver;  // 切换暂停标志
        if (isGameOver)
        {
            // 暂停游戏
            Time.timeScale = 0f;  // 设置时间为 0，暂停所有时间相关的操作
            gameOverMenu.SetActive(true);  // 显示暂停菜单
            scoreText.text = "Score: " + GameManager.Instance.score;
            pauseButton.SetActive(false);
        }
    
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        // 检查触碰的对象是否是 Player
        if (other.CompareTag("Player"))
        {
            // 设置 GameManager 的 Score 为 "Game Over"
            ToggleGameOver();
            //scoreManager.SetGameOverScore();
            

            // 停止游戏，可以通过暂停游戏或直接结束游戏来实现
            //Time.timeScale = 0f;  // 停止游戏，暂停时间
            Debug.Log("game over");
        }
    }
}
