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

    private float lastTime, deltaTime, timer, delay;


    // Start is called before the first frame update
    void Start()
    {
        lastTime = 0f;
        deltaTime = 0f;
        timer = 0f;

        soundManager.PlaySong(soundManager.GetSong(0));
        bpm = soundManager.GetSong(0).GetBPM();
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
                if (timer >= (60f / bpm))
                {
                    //Create the note
                    ((GameObject)Instantiate(note, this.transform.position, Quaternion.identity)).GetComponent<Transform>().parent = GetComponent<Transform>();
                    timer -= (60f / bpm);
                }
            }
    }
}
