using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum IdentitySound { PashekoshLogo, SloppyStudioLogo }
public enum GameFeedback { BadInsectKill, GoodInsectKill, PlayerLevelUp, WrongInsect, CountDown }
public enum UIFeedback { Alert, ButtonClick, BuyOrSelectItem, KillerLevelUp, Locked, Notif, PowerupsUnlock, PULevelup }

[RequireComponent(typeof(AudioSource))]
public class SFXPlayer : Singleton<SFXPlayer>
{
    AudioSource Player;
    [Space]
    [SerializeField] List<AudioClip> Clips = new List<AudioClip>();
    [Space]
    [SerializeField] AudioSource PUPlayer;




    public void PlaySFX(PowerUpType puType)
    {
        int index = ReturnIndex(puType.ToString());
        PUPlayer.PlayOneShot(Clips[index]);
    }
    public void PlaySFX(IdentitySound identitySound)
    {
        int index = ReturnIndex(identitySound.ToString());
        Player.PlayOneShot(Clips[index]);
    }
    public void PlaySFX(WeaponType weaponSound)
    {
        int index = ReturnIndex(weaponSound.ToString());
        Player.PlayOneShot(Clips[index]);
    }
    public void PlaySFX(GameFeedback gameFeedback)
    {
        int index = ReturnIndex(gameFeedback.ToString());
        Player.PlayOneShot(Clips[index]);
    }
    public void PlaySFX(UIFeedback uiFeedback)
    {
        int index = ReturnIndex(uiFeedback.ToString());
        Player.PlayOneShot(Clips[index]);
    }

    public void MuteSFXPlayer(bool isMute)
    {
        Player.mute = isMute;
        PUPlayer.mute = isMute;
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


    int ReturnIndex(string name)
    {
        int clipsCount = Clips.Count;
        for (int i = 0; i < clipsCount; i++)
        {
            if(Clips[i].name == name)
            {
                return i;
            }
        }
        return -1;
    }


}//EndClasss
