using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        // **保存难度到 PlayerPrefs**
        //PlayerPrefs.SetInt("SelectedDifficulty", difficulty);
        //PlayerPrefs.Save();

        // 切换到游戏场景
        SceneManager.LoadScene("newscene");
    }
    public void GoShop()
    {
        SceneManager.LoadScene("shop");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
