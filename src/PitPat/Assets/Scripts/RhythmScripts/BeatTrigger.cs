using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 public class BeatTrigger : MonoBehaviour
 {
    private SpriteRenderer spriteRenderer;
    public Sprite defaultImage;
    public Sprite pressedImage;

    //Keeps track of the amount of beats total and how many were hit. The counter will be reset every 10 beats
    public static int beatsCounter;
    public static int beatsHit;

    public static bool canBePressed = false;

    //Will be watched by PlayerController and immediately set to false after turning true (so that PlayerController can send that notification to other scripts)
    public static bool beatEntered = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Beat"))
        {
            canBePressed = true;
            beatEntered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Beat"))
        {
            beatsCounter++;
            if(beatsCounter>10)
            {
                beatsCounter = 1;
            }
            canBePressed = false;
        }
    }
}
