using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;  // 游戏暂停时显示的菜单（可以是一个 UI 面板）
    private bool isPaused = false;  // 用于判断当前是否暂停

    void Start()
    {
        // 初始时游戏没有暂停
        pauseMenu.SetActive(false);  // 暂停菜单默认不可见
    }

    // 切换暂停状态
    public void TogglePause()
    {
        isPaused = !isPaused;  // 切换暂停标志
        if (isPaused)
        {
            // 暂停游戏
            Time.timeScale = 0f;  // 设置时间为 0，暂停所有时间相关的操作
            pauseMenu.SetActive(true);  // 显示暂停菜单
        }
        else
        {
            // 恢复游戏
            Time.timeScale = 1f;  // 恢复正常时间流动
            pauseMenu.SetActive(false);  // 隐藏暂停菜单
        }
    }

    // 退出游戏（可以用一个按钮来退出）
    public void QuitGame()
    {
        // 恢复时间流动（防止暂停状态被保留）
        Time.timeScale = 1f;

        // 加载 Start 场景
        SceneManager.LoadScene("start menu");  // 确保场景名称与实际一致
    }
    public void RetryGame()
    {
        Time.timeScale = 1f;

        // 加载 Start 场景
        SceneManager.LoadScene("newscene");  // 确保场景名称与实际一致
    }
}
