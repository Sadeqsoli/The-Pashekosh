using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [Header("Sfx Player")]
    [Space]
    [SerializeField] AudioPlayer SFXPlayer;


    [Header("Media Player")]
    [Space]
    [SerializeField] AudioPlayer MusicPlayer;


    void Start()
    {
        SFXPlayer.InitializingAllClips(DB.LocalSFXsDIR(),false);
        MusicPlayer.InitializingAllClips(DB.LocalMusicsDIR(),true);
    }




}//EndClassss
