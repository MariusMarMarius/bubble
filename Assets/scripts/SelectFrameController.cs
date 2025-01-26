using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectFrameController : MonoBehaviour
{
    public RectTransform selectFrame;  // 选择框的 RectTransform
    public Vector2[] positions;        // 存储所有皮肤的固定位置
    private int currentIndex = 0;      // 当前选中的索引

    public bool[] isSkinAvailable;     // 皮肤解锁状态数组

    void Start()
    {
        // 初始化时将选择框固定到第一个位置
        if (positions.Length > 0)
        {
            currentIndex = 0;
            UpdatePosition();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Move(-1); // 向左移动
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Move(1); // 向右移动
        }
        else if (Input.GetKeyDown(KeyCode.Return)) // 按回车键选择
        {
            SelectSkin();
        }
    }

    void Move(int direction)
    {
        int newIndex = currentIndex + direction;

        // 确保索引在数组范围内
        if (newIndex >= 0 && newIndex < positions.Length)
        {
            currentIndex = newIndex;
            UpdatePosition();
        }
    }

    void UpdatePosition()
    {
        // 将选择框移动到当前索引位置
        selectFrame.anchoredPosition = positions[currentIndex];
    }

    void SelectSkin()
    {
        if (isSkinAvailable.Length > currentIndex && isSkinAvailable[currentIndex])
        {
            Debug.Log("皮肤已解锁，进入新场景");
            PlayerPrefs.SetInt("SelectedSkin", currentIndex); // 存储选择的皮肤索引
            SceneManager.LoadScene("NewScene"); // 切换到新场景
        }
        else
        {
            Debug.Log("皮肤未解锁");
        }
    }
}

