﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour
{
    [SerializeField] TMP_InputField UsernameInputField;
    [SerializeField] Button SubmitButton;


    private void Start()
    {
        UsernameInputField.onValueChanged.AddListener(UsernameEvaluation);
        SubmitButton.onClick.AddListener(Submit);
        SubmitButton.interactable = false;
    }

    void UsernameEvaluation(string usernameInput)
    {
        if (usernameInput.Length >= 3)
        {
            SubmitButton.interactable = true;
        }
        else
        {
            SubmitButton.interactable = false;
        }
    }

    void Submit()
    {
        SFXPlayer.Instance.PlaySFX(UIFeedback.ButtonClick);
        string username = UsernameInputField.text;
        UserRepo.PushUsername(username);
        UserRepo.SetUserSignedIn(true);
        gameObject.transform.Scaler(TTScale.ScaleDown);
    }

}//EndClassss
