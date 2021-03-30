using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Songs : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> songs;
    [SerializeField]
    private List<int> songBPM;
    [Tooltip("How many seconds the beat is off center")]
    [SerializeField]
    private List<float> beatDelay;
    [SerializeField]
    private AudioSource bgmSource;

    public static List<Song> songsList=new List<Song>();

    private void Start()
    {
        int songsCount = songs.Count;
        int bpmCount = songBPM.Count;
        int delayCount = beatDelay.Count;

        //If the lists are uneven, only iterate up to the smallest list size
        int maxIndex = songsCount;
        if(maxIndex>bpmCount)
        {
            Debug.Log("ERROR: Lists not even");
            maxIndex = bpmCount;
        }
        if(maxIndex>delayCount)
        {
            Debug.Log("ERROR: Lists not even");
            maxIndex = delayCount;
        }
        for(int x=0;x<maxIndex;x++)
        {
            songsList.Add(new Song(songs[x], songBPM[x], beatDelay[x]));
        }

        if(bgmSource==null)
        {
            bgmSource=this.gameObject.AddComponent<AudioSource>();
        }
        bgmSource.loop = true;

        PlaySong(songsList[0]);
    }

    public Song GetSong(int index)
    {
        if(index>=songsList.Count)
        {
            //If requested index out of range, return first song
            return songsList[0];
        }
        else
        {
            return songsList[index];
        }
    }

    public Song GetRandomSong(int index)
    {
        int randomIndex = Random.Range(0, songsList.Count);
        return songsList[randomIndex];
    }

    public void PlaySong(Song song)
    {
        bgmSource.clip = song.GetSong();
        bgmSource.Play();
    }

    public void ToggleMute()
    {
        bgmSource.mute = !bgmSource.mute;

    }
}
