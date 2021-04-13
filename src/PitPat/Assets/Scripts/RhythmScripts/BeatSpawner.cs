using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSpawner : MonoBehaviour
{
    //===================================
    //For now this will simply be a hardcoding 120 beat
    //===================================
    [SerializeField]
    private GameObject note;
    [SerializeField]
    private int bpm;
    [SerializeField]
    private Songs soundManager;
    [Tooltip("The amount of seconds the player has to hit the beat within. This goes both before and after the beat actually hits.")]
    [SerializeField]
    private float hitTolerance;
    //TODO: Change to percentage between beats?
    [Tooltip("The background rectangle for the beat lane. Width/position used to determine lerp placement.")]
    [SerializeField]
    private GameObject beatLane;
    [SerializeField]
    private GameObject beatMarker;

    public static bool canBePressed = false;
    //Will be watched by PlayerController and immediately set to false after turning true (so that PlayerController can send that notification to other scripts)
    public static bool beatEntered = false;

    private float lastTime, deltaTime, timer, delay, beatTime;
    private bool hitInRange;

    private GameObject beat;
    private Vector2 lerpStartPosition;
    private Vector2 lerpEndPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastTime = 0f;
        deltaTime = 0f;
        timer = 0f;

        //bpm = soundManager.GetSong(0).GetBPM();
        bpm = 120;
        beatTime = 1.0f/(bpm / 60.0f);
        Debug.Log("Beat Time: "+ beatTime);

        lerpStartPosition = beatLane.transform.position;
        lerpEndPosition = beatLane.transform.position;
        lerpStartPosition.x=lerpStartPosition.x+beatLane.GetComponent<Renderer>().bounds.size.x / 2;
        lerpEndPosition.x = lerpEndPosition.x - beatLane.GetComponent<Renderer>().bounds.size.x / 2;
        beat=Instantiate(beatMarker, lerpStartPosition, Quaternion.identity);
        ((GameObject)Instantiate(beatMarker, lerpStartPosition, Quaternion.identity)).GetComponent<Transform>().parent = GetComponent<Transform>();
        ((GameObject)Instantiate(beatMarker, lerpEndPosition, Quaternion.identity)).GetComponent<Transform>().parent = GetComponent<Transform>();
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

            //beat.transform.position = Vector3.Lerp(lerpStartPosition, lerpEndPosition, timer*(1/beatTime));

            // The center of the arc
            Vector3 center = beatLane.transform.position;
            // move the center a bit downwards to make the arc vertical
            center -= new Vector3(0, 0.5f, 0);

            // Interpolate over the arc relative to center
            Vector3 riseRelCenter = (Vector3)lerpStartPosition - center;
            Vector3 setRelCenter = (Vector3)lerpEndPosition - center;

            // The fraction of the animation that has happened so far is
            // equal to the elapsed time divided by the desired time for
            // the total journey.
            float fracComplete = timer / beatTime;

            beat.transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
            beat.transform.position += center;

            if (timer>=beatTime)
            {
                Vector2 tempPosition = lerpStartPosition;
                lerpStartPosition = lerpEndPosition;
                lerpEndPosition = tempPosition;
            }

            if (timer>=beatTime-hitTolerance&&canBePressed==false)
            {
                float quick = beatTime + hitTolerance;
                canBePressed = true;
            }
            else if(timer>=beatTime+hitTolerance)
            {
                timer -= beatTime+hitTolerance;
                canBePressed = false;
            }
            else if(timer<beatTime-hitTolerance)
            {
                canBePressed = false;
            }
            /*if (timer >= (60f / bpm))
            {
                //Create the note
                ((GameObject)Instantiate(note, this.transform.position, Quaternion.identity)).GetComponent<Transform>().parent = GetComponent<Transform>();
                timer -= (60f / bpm);
            }*/
            }

    }

}
