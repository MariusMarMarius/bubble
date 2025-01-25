using UnityEngine;

public class Collectable : MonoBehaviour
{

    public float speed;

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    public void setup(float s)
    {
        speed = s;
    }

}
