using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MediaPlayer : Singleton<MediaPlayer>
{
    AudioSource Player;
    [Space]
    [SerializeField] List<AudioClip> Clips = new List<AudioClip>();

    int currentClipNumb = -1;



    public void LoopingMP(bool isLopping = false)
    {
        Player.loop = isLopping;
    }

    public void ShufflePlayMP(bool isLopping = false)
    {
        int rnd = Random.Range(0, Clips.Count);
        Player.Stop();
        Player.loop = isLopping;
        Player.clip = Clips[rnd];
        Player.Play();
    }
    public void PlayMP(bool isLopping = false)
    {
        currentClipNumb++;
        if(currentClipNumb < 0 || currentClipNumb >= Clips.Count)
        {
            Debug.Log("Out of Index: " + currentClipNumb);
            currentClipNumb = 0;
        }
        Player.Stop();
        Player.playOnAwake = false;
        Player.loop = isLopping;
        Player.clip = Clips[currentClipNumb];
        Player.Play();
    }



    void Start()
    {
        currentClipNumb = -1;
        Player = GetComponent<AudioSource>();
        Player.playOnAwake = false;
        InitializeMediaClips();
    }//Awakeeeee

    void InitializeMediaClips()
    {
        AudioClip[] ACs = Resourcer.ListOfClips(DB.LocalMusicsDIR());
        int clipLength = ACs.Length;
        for (int i = 0; i < clipLength; i++)
        {
            Clips.Add(ACs[i]);
        }
    }


}//EndClasss
