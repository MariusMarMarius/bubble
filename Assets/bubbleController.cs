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

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("insidee");

        // Überprüfen, ob der Spieler die "Bubble" berührt hat
        if (other.CompareTag("Player"))
        {
            Debug.Log("Bubble wurde vom Spieler getroffen!");

            other.GetComponent<playerController>().jump(8);

            Destroy(gameObject); // Zerstört die Bubble
        }
    }
}
