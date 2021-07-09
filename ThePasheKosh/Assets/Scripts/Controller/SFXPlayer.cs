using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SFXType { ButtonClick }

[RequireComponent(typeof(AudioSource))]
public class SFXPlayer : Singleton<SFXPlayer>
{
    AudioSource Player;
    [Space]
    [SerializeField] List<AudioClip> Clips = new List<AudioClip>();




    public void PlaySFX(SFXType sfxType)
    {
        Player.PlayOneShot(Clips[(int)sfxType]);
    }




    void Start()
    {
        Player = GetComponent<AudioSource>();
        Player.playOnAwake = false;
        InitializeSFXClips();
    }//Awakeeeee

    void InitializeSFXClips()
    {
        AudioClip[] ACs = Resourcer.ListOfClips(DB.LocalSFXsDIR());
        int clipLength = ACs.Length;
        for (int i = 0; i < clipLength; i++)
        {
            Clips.Add(ACs[i]);
        }
    }

}
