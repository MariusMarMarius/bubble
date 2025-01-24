using UnityEngine;

public class bubbleController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector2 pushDirection = (collision.transform.position - transform.position).normalized;

            collision.GetComponent<playerController>().bubbleKnock(pushDirection, 5f);

            Destroy(gameObject); // Zerstört die Bubble
        }
    }
}
