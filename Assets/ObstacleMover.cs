using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float speed = 5f;  // 控制移动速度
    public float destroyX = -15f;  // 超出这个位置销毁

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        // 如果障碍物移出了屏幕左侧，就销毁
        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}
