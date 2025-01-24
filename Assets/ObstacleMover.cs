using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float speed = 5f;  // �����ƶ��ٶ�
    public float destroyX = -15f;  // �������λ������

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        // ����ϰ����Ƴ�����Ļ��࣬������
        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}
