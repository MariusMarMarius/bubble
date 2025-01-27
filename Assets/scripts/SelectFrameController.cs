using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectFrameController : MonoBehaviour
{
    public RectTransform selectFrame;  // ѡ���� RectTransform
    public Vector2[] positions;        // �洢����Ƥ���Ĺ̶�λ��
    private int currentIndex = 0;      // ��ǰѡ�е�����

    public bool[] isSkinAvailable;     // Ƥ������״̬����

    void Start()
    {
        // ȷ�����鲻Ϊ�գ�������0��Ƥ��Ĭ�Ͻ���
        if (isSkinAvailable == null || isSkinAvailable.Length < positions.Length)
        {
            isSkinAvailable = new bool[positions.Length]; // ��ʼ������

        }

        isSkinAvailable[0] = true; // 0��Ƥ��Ĭ�Ͻ���
        isSkinAvailable[1] = PlayerPrefs.GetInt("Skin1Owned", 0) == 1;
        isSkinAvailable[2] = PlayerPrefs.GetInt("Skin2Owned", 0) == 1;

        // ��ʼ��ѡ��򵽵�һ��λ��
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
            Move(-1); // �����ƶ�
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Move(1); // �����ƶ�
        }
        isSkinAvailable[1] = PlayerPrefs.GetInt("Skin1Owned", 0) == 1;
        isSkinAvailable[2] = PlayerPrefs.GetInt("Skin2Owned", 0) == 1;
    }

    void Move(int direction)
    {
        int newIndex = currentIndex + direction;

        // ȷ�����������鷶Χ��
        if (newIndex >= 0 && newIndex < positions.Length)
        {
            currentIndex = newIndex;
            UpdatePosition();
        }
    }

    void UpdatePosition()
    {
        // �ƶ�ѡ���
        selectFrame.anchoredPosition = positions[currentIndex];

        // **�Զ�ѡ��Ƥ��**
        SelectSkin();
    }

    void SelectSkin()
    {
        if (isSkinAvailable != null && isSkinAvailable.Length > currentIndex && isSkinAvailable[currentIndex])
        {
            Debug.Log("��ǰѡ��Ƥ����" + currentIndex);
            PlayerPrefs.SetInt("SelectedSkin", currentIndex); // �洢Ƥ������
            PlayerPrefs.Save(); // ȷ������д��
        }
        else
        {
            Debug.Log("��ǰƤ��δ����");
        }
    }
}
