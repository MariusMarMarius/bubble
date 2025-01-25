using UnityEngine;

public class Combination : MonoBehaviour
{
    public Bubble[] bubbles;

    public float speed;

    public Layer entryL;
    public Layer exitL;

    public Transform leaveAnchor;


    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    public void Setup(float s)
    {
        speed = s;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("COLL");
        if (collision.CompareTag("GameBoard"))
        {
            Debug.Log("GB");
        }
    }
}

public enum Layer
{
    Low,
    Middle,
    High
}
