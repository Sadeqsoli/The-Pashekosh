using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using RTLTMPro;
using UnityEditor;
using UnityEngine;

public class HitScore : MonoBehaviour
{
    #region Fields

    public GameObject scoreHit;

    private RTLTextMeshPro _rtlTextMeshPro;

    #endregion

    #region Methods

    public void Awake()
    {
        _rtlTextMeshPro = GetComponent<RTLTextMeshPro>();
    }

    public void Initialize(int scoreAmount, Color color)
    {
        _rtlTextMeshPro.color = color;
        if (scoreAmount > 0)
            _rtlTextMeshPro.text = "+ " + scoreAmount;
        else
            _rtlTextMeshPro.text = "- " + -scoreAmount;

        scoreHit.transform.localScale = Vector3.zero;
        scoreHit.transform.DOScale(Vector3.one, 1f).OnComplete(
            () => Destroy(scoreHit.gameObject)
        );
    }

    public void Initialize(string scoreAmount, Color color)
    {
        _rtlTextMeshPro.color = color;

        _rtlTextMeshPro.text = scoreAmount;

        scoreHit.transform.localScale = Vector3.zero;
        scoreHit.transform.DOScale(Vector3.one, 1f).OnComplete(
            () => Destroy(scoreHit.gameObject)
        );
    }
    #endregion


}
