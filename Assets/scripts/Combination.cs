using UnityEngine;

public class Combination : MonoBehaviour
{
    public BubbleWhiteOrRandom[] bubbles;
    public SpriteRenderer[] grounds;

    public Sprite ground1;
    public Sprite ground2;

    public Layer entryL;
    public Layer exitL;

    public Transform leaveAnchor;


    private void Start()
    {
        foreach (SpriteRenderer r in grounds)
        {
            if (Random.Range(0, 100) <= 50)
            {
                r.sprite = ground1;
            } else
            {
                r.sprite = ground2;
            }
        }
        

        foreach (BubbleWhiteOrRandom b in bubbles)
        {
            if (!b.white)
            {
                b.bubble.setRandomColor();
            }else
            {
                b.bubble.setWhiteColor();
            }
            b.bubble.setRandomSize();
        }
    }
}

public enum Layer
{
    Low,
    Middle,
    High
}
