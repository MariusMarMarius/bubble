using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 100f; // 旋转速度

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime); // 绕 Z 轴旋转
    }
}
