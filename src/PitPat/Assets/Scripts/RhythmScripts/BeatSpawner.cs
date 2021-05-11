using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSpawner : MonoBehaviour
{
    [SerializeField]
    private int bpm;
    [SerializeField]
    private Songs soundManager;
    [Tooltip("The amount of seconds the player has to hit the beat within. This goes both before and after the beat actually hits.")]
    [SerializeField]
    private float hitTolerance;
    //TODO: Change to percentage between beats?

    public static bool canBePressed = false;
    //Will be watched by PlayerController and immediately set to false after turning true (so that PlayerController can send that notification to other scripts)
    public static bool beatEntered = false;
    public static bool aiCanMove = false;

    public static float timer;
    private float lastTime, deltaTime, delay, beatTime;
    private bool hitInRange;
    private bool aiMoved=false;

    // Start is called before the first frame update
    void Start()
    {
        lastTime = 0f;
        deltaTime = 0f;
        timer = 0f;

        bpm = Songs.GetSong(0).GetBPM();
        //bpm = 120;
        beatTime = 1.0f/(bpm / 60.0f);
        Debug.Log("Beat Time: "+ beatTime);
    }

    // Update is called once per frame
    void Update()
    {
         if (delay > 0)
         {
              delay -= Time.deltaTime;
         }
         else
         {
            timer += Time.deltaTime;

            if (timer>=beatTime-hitTolerance&&canBePressed==false)
            {
                canBePressed = true;
                aiCanMove = false;
            }
            else if(timer>=beatTime+hitTolerance)
            {
                timer -= beatTime+hitTolerance;
                aiMoved = false;
                canBePressed = false;
                UIMetronome.FlipMetronome();
            }
            else if(timer<beatTime-hitTolerance)
            {
                canBePressed = false;
            }
            if(timer>=beatTime/2&&aiMoved==false)
            {
                aiCanMove = true;
                aiMoved = true;
            }
         }
    }
}
