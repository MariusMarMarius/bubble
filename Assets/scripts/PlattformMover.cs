using UnityEngine;

public class PlattformMover : MonoBehaviour
{
    //public float[] speedOptions = { 2.0f, 5.0f, 10.0f, 20.0f }; // 固定的速度选项
    private float speed = 1.0f;           // 当前速度

    public float destroyX = -15f;  // 超出这个位置销毁

    public float acceleration = 1f;  // 每秒加速度

    void Start()
    {

    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

    }
}
