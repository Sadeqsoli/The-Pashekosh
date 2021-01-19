using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    #region Fields

    public Button backgroundSound;
    [FormerlySerializedAs("insectSounds")] public Button insectsSound;

    public Sprite unMuteSprite;
    public Sprite muteSprite;
    #endregion

    #region Propertie
    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    void Start()
    {
        backgroundSound.image.sprite = unMuteSprite;
        insectsSound.image.sprite = unMuteSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion

    #region Methods

    public void MuteUnmuteSound(Button clickedButton)
    {
        if (clickedButton == backgroundSound)
        {
            if (clickedButton.image.sprite == unMuteSprite)
            {
                EventManager.TriggerEvent(Events.BackgroundSound, false);
                clickedButton.image.sprite = muteSprite;
            }
            else
            {
                EventManager.TriggerEvent(Events.BackgroundSound, true);
                clickedButton.image.sprite = unMuteSprite;
            }
        }
        else if (clickedButton == insectsSound)
        {
            if (clickedButton.image.sprite == unMuteSprite)
            {
                EventManager.TriggerEvent(Events.InsectsSound, false);
                clickedButton.image.sprite = muteSprite;
            }
            else
            {
                EventManager.TriggerEvent(Events.InsectsSound, true);
                clickedButton.image.sprite = unMuteSprite;
            }
        }
    }
    #endregion
}
