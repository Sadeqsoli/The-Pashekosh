using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [Header("Sfx Player")]
    [Space]
    [SerializeField] SFXPlayer sfxPlayer;


    [Header("Media Player")]
    [Space]
    [SerializeField] MediaPlayer MusicPlayer;


}//EndClassss
