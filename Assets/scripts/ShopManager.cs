using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartGame()
    {
        
        // 切换到游戏场景
        SceneManager.LoadScene("newscene");
    }

    public void BackHome()
    {
        
        // 切换到游戏场景
        SceneManager.LoadScene("start menu");
    }
}
