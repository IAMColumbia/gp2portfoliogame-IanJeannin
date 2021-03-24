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

    private float lastTime, deltaTime, timer;


    // Start is called before the first frame update
    void Start()
    {
        lastTime = 0f;
        deltaTime = 0f;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
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
