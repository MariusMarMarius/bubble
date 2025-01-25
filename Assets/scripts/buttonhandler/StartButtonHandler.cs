using UnityEngine;
using UnityEngine.SceneManagement;  // 引入加载场景的命名空间

public class StartButtonHandler : MonoBehaviour
{
    // 按钮点击时调用的函数
    public void OnStartButtonClicked()
    {
        // 通过场景名加载新的场景
        SceneManager.LoadScene("newscene");
    }
}
