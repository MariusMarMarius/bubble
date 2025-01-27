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
        // 确保数组不为空，并设置0号皮肤默认解锁
        if (isSkinAvailable == null || isSkinAvailable.Length < positions.Length)
        {
            isSkinAvailable = new bool[positions.Length]; // 初始化数组

        }

        isSkinAvailable[0] = true; // 0号皮肤默认解锁
        isSkinAvailable[1] = PlayerPrefs.GetInt("Skin1Owned", 0) == 1;
        isSkinAvailable[2] = PlayerPrefs.GetInt("Skin2Owned", 0) == 1;

        // 初始化选择框到第一个位置
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
        isSkinAvailable[1] = PlayerPrefs.GetInt("Skin1Owned", 0) == 1;
        isSkinAvailable[2] = PlayerPrefs.GetInt("Skin2Owned", 0) == 1;
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
        // 移动选择框
        selectFrame.anchoredPosition = positions[currentIndex];

        // **自动选择皮肤**
        SelectSkin();
    }

    void SelectSkin()
    {
        if (isSkinAvailable != null && isSkinAvailable.Length > currentIndex && isSkinAvailable[currentIndex])
        {
            Debug.Log("当前选中皮肤：" + currentIndex);
            PlayerPrefs.SetInt("SelectedSkin", currentIndex); // 存储皮肤索引
            PlayerPrefs.Save(); // 确保数据写入
        }
        else
        {
            Debug.Log("当前皮肤未解锁");
        }
    }
}
