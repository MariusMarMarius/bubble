using UnityEngine;

public class PlattformMover : MonoBehaviour
{
    //public float[] speedOptions = { 2.0f, 5.0f, 10.0f, 20.0f }; // �̶����ٶ�ѡ��
    private float speed = 5.0f;           // ��ǰ�ٶ�

    public float destroyX = -15f;  // �������λ������
    private Rigidbody2D rb;

    public float acceleration = 1f;  // ÿ����ٶ�

    void Start()
    {
        // ��ȡ Rigidbody2D ���
        rb = GetComponent<Rigidbody2D>();

        // ��������Ӱ��
        if (rb != null)
        {
            rb.gravityScale = 0;
        }

        // �� speedOptions �����ѡ��һ���ٶ�
        //speed = speedOptions[Random.Range(0, speedOptions.Length)];

        // �����ٶ�
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(-speed, 0f);  // �����ƶ�
        }
    }

    void Update()
    {
        // ��� Rigidbody2D Ϊ�գ�����ʹ�� transform ���ֶ��ƶ�
        if (rb == null)
        {
            // ʹ�� transform �����ƶ�
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else
        {
            // ����� Rigidbody2D��ʹ�����������ٶ�
            speed += acceleration * Time.deltaTime;  // ����ʱ�������ٶ�
            rb.linearVelocity = new Vector2(-speed, 0f);  // �����ٶ�
        }

        // ����ϰ����Ƴ�����Ļ��࣬������
        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}
