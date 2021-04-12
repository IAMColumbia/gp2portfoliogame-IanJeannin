using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song
{
    private AudioClip song;
    private int songBPM;
    private float beatDelay;

    public Song(AudioClip newSong,int newBPM, float newDelay)
    {
        song = newSong;
        songBPM = newBPM;
        beatDelay = newDelay;
    }

    public AudioClip GetSong()
    {
        return song;
    }

    public int GetBPM()
    {
        return songBPM;
    }

    public float GetDelay()
    {
        return beatDelay;
    }
}
