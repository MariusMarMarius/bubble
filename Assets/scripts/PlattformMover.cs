using UnityEngine;

public class PlattformMover : MonoBehaviour
{
    //public float[] speedOptions = { 2.0f, 5.0f, 10.0f, 20.0f }; // �̶����ٶ�ѡ��
    private float speed = 1.0f;           // ��ǰ�ٶ�

    public float destroyX = -15f;  // �������λ������

    public float acceleration = 1f;  // ÿ����ٶ�

    void Start()
    {

    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

    }
}
