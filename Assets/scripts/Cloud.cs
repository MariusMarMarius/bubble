using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float speed;



    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
