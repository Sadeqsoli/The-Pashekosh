using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    AudioSource Player;
    [Space]
    [SerializeField] List<AudioClip> Clips = new List<AudioClip>();





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
    public void PlayMP(int i, bool isLopping = false)
    {
        Player.Stop();
        Player.playOnAwake = false;
        Player.loop = isLopping;
        Player.clip = Clips[i];
        Player.Play();
    }


    public void InitializingAllClips(string dirPath, bool isMusic)
    {
        DirectoryInfo dir = new DirectoryInfo(dirPath);
        FileInfo[] musicsInfo = dir.GetFiles("*.*");
        foreach (FileInfo music in musicsInfo)
        {
            if (isMusic)
                NetCenter.Instance.DownloadSound(DB.LocalMusics(music.Name), AddClips);
            else
                NetCenter.Instance.DownloadSound(DB.LocalSFXs(music.Name), AddClips);

        }
    }
    void Awake()
    {
        Player = GetComponent<AudioSource>();
        Player.playOnAwake = false;
    }//Awakeeeee






    void AddClips(AudioClip clip)
    {
        Clips.Add(clip);
    }







}//EndClasss
