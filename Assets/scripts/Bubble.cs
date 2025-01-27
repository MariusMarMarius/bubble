using UnityEngine;
using System;
public class Bubble : MonoBehaviour
{
    private string spritePath = "Sprites/bubble/";

    public GameplayColor color;

    private Animator ani;


    public float[] speedOptions = { 2.0f, 5.0f, 10.0f, 20.0f };
    private float speed;

    private void Start()
    {
        //speed = speedOptions[UnityEngine.Random.Range(0, speedOptions.Length)];
    }

    private void Update()
    {
        //transform.position += Vector3.left * speed * Time.deltaTime;
    }

    public void Setup(GameplayColor c, float s)
    {

        AssignColor(c);
        SetSize(s);
    }

    public void setRandomSize()
    {
        float size = UnityEngine.Random.Range(1.5f, 2f);
        SetSize(size);
    }

    public void setRandomColor()
    {
        Array enumValues = GameplayColor.GetValues(typeof(GameplayColor));
        GameplayColor c = (GameplayColor)enumValues.GetValue(UnityEngine.Random.Range(0, enumValues.Length));


        AssignColor(c);
    }

    public void setWhiteColor()
    {
        AssignColor(GameplayColor.WHITE);
    }



    void AssignColor(GameplayColor c)
    {
        color = c;
        ani = GetComponent<Animator>();


        switch (color)
        {
            case GameplayColor.WHITE:

                break;
            case GameplayColor.ORANGE:
                ani.SetTrigger("orangeTrigger");
                break;
            case GameplayColor.GREEN:
                ani.SetTrigger("greenTrigger");
                break;
            case GameplayColor.PINK:
                ani.SetTrigger("pinkTrigger");
                break;
        }

        /*
        string fullPath = spritePath + c.ToString();


        Sprite newSprite = Resources.Load<Sprite>(fullPath);
        if (newSprite != null)
        {
            GetComponent<SpriteRenderer>().sprite = newSprite;
        }
        else
        {
            Debug.Log("DIDNT FIND IMAGE");
        }
        */
    }

    void SetSize(float size)
    {
        transform.localScale = new Vector2(size, size);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<playerController>().color == color || color == GameplayColor.WHITE)
            {
                Vector2 pushDirection = (collision.transform.position - transform.position);
                pushDirection.Normalize();

                collision.GetComponent<playerController>().bubbleKnock(pushDirection, 5f);

            }

            //SpawnSplashEffect();
            GameManager.Instance.IncreaseScore(5);

            AudioClip splashSound = Resources.Load<AudioClip>("voice/bubbleSplash");
            AudioSource audioSource = collision.gameObject.AddComponent<AudioSource>();
            audioSource.clip = splashSound;
            audioSource.Play();

            Destroy(gameObject); // Zerstört die Bubble
        }
    }

        //Bubble splash effect

        /*
    void SpawnSplashEffect()
    {
        Sprite splashSprite = Resources.Load<Sprite>("splash");
        AudioClip splashSound = Resources.Load<AudioClip>("voice/bubbleSplash");

        if (splashSprite != null)
        {
            GameObject splashEffect = new GameObject("BubbleSplash");
            SpriteRenderer renderer = splashEffect.AddComponent<SpriteRenderer>();
            renderer.sprite = splashSprite;

            splashEffect.transform.position = transform.position;
            splashEffect.transform.localScale = transform.localScale / 2;


            AudioSource audioSource = splashEffect.AddComponent<AudioSource>();
            if (splashSound != null)
            {
                audioSource.clip = splashSound;
                audioSource.Play();
                Debug.Log("Voice played");
            }
            else
            {
                Debug.LogWarning("Splash sound not found in Resources/voice folder!");
            }

            Destroy(splashEffect, 2f);
        }
        else
        {
            Debug.LogWarning("Splash sprite not found in Resources folder!");
        }
    }    */
}

[System.Serializable]
public class BubbleWhiteOrRandom
{
    public Bubble bubble;
    public bool white;
}