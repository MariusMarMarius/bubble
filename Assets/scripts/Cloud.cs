using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float speed;

    public GameObject cloud1;
    public GameObject cloud2;
    public GameObject cloud3;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
