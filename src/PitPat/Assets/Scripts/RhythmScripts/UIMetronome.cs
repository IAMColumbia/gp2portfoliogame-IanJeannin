using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMetronome : MonoBehaviour
{
    [Tooltip("The background rectangle for the beat lane. Width/position used to determine lerp placement.")]
    [SerializeField]
    private GameObject beatLane;
    [SerializeField]
    private GameObject beatMarker;

    private GameObject beat;

    private float beatTime=0;
    public static Vector2 lerpStartPosition;
    public static Vector2 lerpEndPosition;

    private void Awake()
    {
        lerpStartPosition = beatLane.transform.position;
        lerpEndPosition = beatLane.transform.position;
        lerpStartPosition.x = lerpStartPosition.x + beatLane.GetComponent<Renderer>().bounds.size.x / 2;
        lerpEndPosition.x = lerpEndPosition.x - beatLane.GetComponent<Renderer>().bounds.size.x / 2;
        beat = Instantiate(beatMarker, lerpStartPosition, Quaternion.identity);
        GameObject leftMarker = Instantiate(beatMarker, lerpEndPosition, Quaternion.identity);
        GameObject rightMarker = Instantiate(beatMarker, lerpStartPosition, Quaternion.identity);
        beat.GetComponent<SpriteRenderer>().sortingLayerName = "Rhythm";
        leftMarker.GetComponent<SpriteRenderer>().sortingLayerName = "Rhythm";
        rightMarker.GetComponent<SpriteRenderer>().sortingLayerName = "Rhythm";
        //((GameObject)Instantiate(beatMarker, lerpEndPosition, Quaternion.identity)).GetComponent<Transform>().parent = GetComponent<Transform>();
    }

    private void Update()
    {
        if(beatTime==0)
        {
            beatTime = 1.0f/(Songs.GetSong(0).GetBPM()/60.0f);
        }
        else
        {// The center of the arc
            Vector3 center = beatLane.transform.position;
            // move the center a bit downwards to make the arc vertical
            center -= new Vector3(0, 0.1f, 0);

            // Interpolate over the arc relative to center
            Vector3 riseRelCenter = (Vector3)lerpStartPosition - center;
            Vector3 setRelCenter = (Vector3)lerpEndPosition - center;

            // The fraction of the animation that has happened so far is
            // equal to the elapsed time divided by the desired time for
            // the total journey.
            float fracComplete = BeatSpawner.timer / beatTime+0.085f;

            beat.transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
            beat.transform.position += center;
        }
    }

    public static void FlipMetronome()
    {
        Vector2 tempPosition = lerpStartPosition;
        lerpStartPosition = lerpEndPosition;
        lerpEndPosition = tempPosition;
    }
}
