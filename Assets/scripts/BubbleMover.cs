using UnityEngine;

public class BubbleMover : MonoBehaviour
{
    public float[] speedOptions = { 2.0f, 5.0f, 10.0f, 20.0f }; // 固定的速度选项
    private float speed;           // 当前速度

    public float destroyX = -15f;  // 超出这个位置销毁
    private Rigidbody2D rb;

    public float acceleration = 1f;  // 每秒加速度

    void Start()
    {
        // 获取 Rigidbody2D 组件
        rb = GetComponent<Rigidbody2D>();


        // 从 speedOptions 中随机选择一个速度
        speed = speedOptions[Random.Range(0, speedOptions.Length)];

        // 设置速度
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(-speed, 0f);  // 向左移动
        }
    }

    void Update()
    {
        // 如果 Rigidbody2D 为空，可以使用 transform 来手动移动
        if (rb == null)
        {
            // 使用 transform 控制移动
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else
        {
            // 如果有 Rigidbody2D，使用它来控制速度
            speed += acceleration * Time.deltaTime;  // 随着时间增加速度
            rb.linearVelocity = new Vector2(-speed, 0f);  // 更新速度
        }

        // 如果障碍物移出了屏幕左侧，就销毁
        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}
