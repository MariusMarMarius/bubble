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
        PlayerPrefs.SetInt("Coins",0);
    }
    public void GoShop()
    {
        SceneManager.LoadScene("shop");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void ResetAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll(); // 清除所有数据
        PlayerPrefs.SetInt("Coins", 100); // 重新设定初始金币
        PlayerPrefs.SetInt("Skin1Owned", 0);
        PlayerPrefs.SetInt("Skin2Owned", 0);
        PlayerPrefs.Save(); // 确保数据写入
    }

}
