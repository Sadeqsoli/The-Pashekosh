using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening.Core;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public enum TTScale { XScaleUp, XScaleDown, ScaleUp, ScaleDown, YScaleUp, YScaleDown, ShakeIt }
public enum TTMove { XMove, Move, YMove,ShakePos, ShakeRot }

public enum TTIFader { IMGFadeIn, IMGFadeOut }
public enum TTIColoring { Coloring, Gradient }

public enum TTTFader { TXTFadeIn, TXTFadeOut }
public enum TTTColoring { SimpleColoring, GlowColoring }
public static class CTween 
{
    static Vector3 zeroX = new Vector3(0, 1, 1);
    static Vector3 zeroY = new Vector3(1, 0, 1);


    //To Scale.
    public static void Scaler(this Transform t, TTScale tweenScaler,UnityAction completeAction = null,
        float tweenTime = 1f, Ease ease = Ease.InOutExpo)
    {
        switch (tweenScaler)
        {
            //Scaling up in X vector.
            case TTScale.XScaleUp:
                t.localScale = zeroX;
                t.gameObject.SetActive(true);
                t.DOScaleX(1, tweenTime)
                    .SetEase(ease)
                    .OnComplete(() =>
                    {
                        completeAction?.Invoke();
                    });
                break;

            //Scaling Down in X vector.
            case TTScale.XScaleDown:
                t.localScale = Vector3.one;
                t.DOScaleX(0, tweenTime)
                    .SetEase(ease)
                    .OnComplete(() =>
                    {
                        t.gameObject.SetActive(false);
                        completeAction?.Invoke();
                    });
                break;

            //Scaling up in X , Y vector.
            case TTScale.ScaleUp:
                t.localScale = Vector3.zero;
                t.gameObject.SetActive(true);
                t.DOScale(Vector3.one, tweenTime)
                    .SetEase(ease)
                    .OnComplete(() =>
                    {
                        completeAction?.Invoke();
                    });
                break;

            //Scaling Down in X , Y vector.
            case TTScale.ScaleDown:

                t.DOScale(Vector3.zero, tweenTime)
                    .SetEase(ease)
                    .OnComplete(() =>
                    {
                        t.gameObject.SetActive(false);
                        completeAction?.Invoke();
                    });

                break;

            //Scaling up in  Y vector.
            case TTScale.YScaleUp:
                t.localScale = zeroY;
                t.gameObject.SetActive(true);
                t.DOScaleY(1, tweenTime)
                    .SetEase(ease)
                    .OnComplete(() =>
                    {
                        completeAction?.Invoke();
                    });
                break;

            //Scaling Down in Y vector.
            case TTScale.YScaleDown:
                t.localScale = Vector3.one;
                t.DOScaleY(0, tweenTime)
                    .SetEase(ease)
                    .OnComplete(() =>
                    {
                        t.gameObject.SetActive(false);
                        completeAction?.Invoke();
                    });
                break;

            //Shake Scaling in every Direction
            case TTScale.ShakeIt:
                t.DOShakeScale(1f, 0.5f, 5)
                    .SetEase(ease)
                    .OnComplete(() =>
                    {
                        completeAction?.Invoke();
                    });
                break;
        }
    }


    //To Move.
    public static void Mover(this Transform t, TTMove tweenMover, UnityAction completeAction = null,
        float tweenTime = 1f,Ease ease = Ease.InOutExpo)
    {
        switch (tweenMover)
        {
            //Scaling up in X vector.
            case TTMove.XMove:
                t.localScale = zeroX;
                t.gameObject.SetActive(true);
                t.DOScaleX(1, tweenTime)
                    .SetEase(ease)
                    .OnComplete(() =>
                    {
                        completeAction?.Invoke();
                    });
                break;

            //Scaling Down in X vector.
            case TTMove.YMove:
                t.localScale = Vector3.one;
                t.DOScaleX(0, tweenTime)
                    .SetEase(ease)
                    .OnComplete(() =>
                    {
                        t.gameObject.SetActive(false);
                        completeAction?.Invoke();
                    });
                break;

            //Scaling up in X , Y vector.
            case TTMove.Move:
                t.localScale = Vector3.zero;
                t.gameObject.SetActive(true);
                t.DOScale(Vector3.one, tweenTime)
                    .SetEase(ease)
                    .OnComplete(() =>
                    {
                        completeAction?.Invoke();
                    });
                break;

            //Shake Position in every Direction
            case TTMove.ShakePos:
                t.DOShakePosition(1f, 0.5f, 5)
                    .SetEase(ease)
                    .OnComplete(() =>
                    {
                        completeAction?.Invoke();
                    });
                break;

            //Shake Rotation in every Direction
            case TTMove.ShakeRot:
                t.DOShakeRotation(1f, 0.5f, 5)
                    .SetEase(ease)
                    .OnComplete(() =>
                    {
                        completeAction?.Invoke();
                    });
                break;
        }
    }





    //For float numbers.
    public static void ToFloat(float starter,float endValue,float tweenTime = 1f,
        UnityAction updateAction = null,UnityAction completeAction = null, Ease ease = Ease.InOutExpo)
    {
        DOTween.To(() => starter, x => starter = x, endValue, tweenTime)
            .SetEase(ease)
            .OnUpdate(() => { updateAction?.Invoke(); })
            .OnComplete(() => { completeAction?.Invoke(); });

    }


    //For Int numbers.
    public static void ToInt(int starter, int endValue,float tweenTime = 1f,
        UnityAction updateAction = null,UnityAction completeAction = null, Ease ease = Ease.InOutExpo)
    {
        DOTween.To(() => starter, x => starter = x, endValue, tweenTime)
            .SetEase(ease)
            .OnUpdate(() => { updateAction?.Invoke(); })
            .OnComplete(() => { completeAction?.Invoke(); });

    }

    //For Vector3 numbers.
    public static void ToVector3(Vector3 starter, Vector3 endValue,float tweenTime = 1f,
        UnityAction updateAction = null,UnityAction completeAction = null, Ease ease = Ease.InOutExpo)
    {
        DOTween.To(() => starter, x => starter = x, endValue, tweenTime)
            .SetEase(ease)
            .OnUpdate(() => { updateAction?.Invoke(); })
            .OnComplete(() => { completeAction?.Invoke(); });

    }
    










    //To Fade Image.
    public static void IMGFader(this Image IMG, TTIFader tweenFader, UnityAction completeAction = null, 
        float tweenTime = 1f, Ease ease = Ease.InOutExpo)
    {
        switch (tweenFader)
        {
            case TTIFader.IMGFadeIn:
                IMG.DOFade(1f, tweenTime)
            .SetEase(ease)
            .OnComplete(() =>
            {
                completeAction?.Invoke();
            });
                break;
            case TTIFader.IMGFadeOut:
                IMG.DOFade(0f, tweenTime)
            .SetEase(ease)
            .OnComplete(() =>
            {
                completeAction?.Invoke();
            });
                break;
        }
    }

    //To Color Image.
    public static void IMGColoring(this Image IMG, TTIColoring tweenFader, Color color = default, Gradient gradient = default,
        UnityAction completeAction = null, float tweenTime = 1f,  Ease ease = Ease.InOutExpo)
    {
        switch (tweenFader)
        {
            case TTIColoring.Coloring:
                IMG.DOColor(color, tweenTime)
            .SetEase(ease)
            .OnComplete(() =>
            {
                completeAction?.Invoke();
            });
                break;
            case TTIColoring.Gradient:
                IMG.DOGradientColor(gradient, tweenTime)
            .SetEase(ease)
            .OnComplete(() =>
            {
                completeAction?.Invoke();
            });
                break;
        }
    }
    //To Fill Image.
    public static void IMGFiller(this Image IMG, float filAmount, UnityAction completeAction = null,
        float tweenTime = 1f, Ease ease = Ease.InOutExpo)
    {
        IMG.DOFillAmount(filAmount, tweenTime)
            .SetEase(ease)
            .OnComplete(() =>
            {
                completeAction?.Invoke();
            });
    }




    //To Fade TextmeshPro.
    public static void TXTFader(this TextMeshProUGUI TXT, TTTFader tweenFader, UnityAction completeAction = null,
        float tweenTime = 1f, Ease ease = Ease.InOutExpo)
    {
        switch (tweenFader)
        {
            case TTTFader.TXTFadeIn:
                TXT.DOFade(1f, tweenTime)
            .SetEase(ease)
            .OnComplete(() =>
            {
                completeAction?.Invoke();
            });
                break;
            case TTTFader.TXTFadeOut:
                TXT.DOFade(0f, tweenTime)
            .SetEase(ease)
            .OnComplete(() =>
            {
                completeAction?.Invoke();
            });
                break;

        }
    }

    //To Color TextmeshPro.
    public static void TXTColoring(this TextMeshProUGUI TXT, TTTColoring tweenFader, Color color,
       UnityAction completeAction = null, float tweenTime = 1f, Ease ease = Ease.InOutExpo)
    {
        switch (tweenFader)
        {
            case TTTColoring.SimpleColoring:
                TXT.DOColor(color, tweenTime)
            .SetEase(ease)
            .OnComplete(() =>
            {
                completeAction?.Invoke();
            });
                break;
            case TTTColoring.GlowColoring:
                TXT.DOGlowColor(color, tweenTime)
            .SetEase(ease)
            .OnComplete(() =>
            {
                completeAction?.Invoke();
            });
                break;

        }
    }

    //To Write in TextmeshPro.
    public static void Texter(this TextMeshProUGUI TXT, string textSTR, UnityAction completeAction = null,
        float tweenTime = 1f, Ease ease = Ease.InOutExpo)
    {
        TXT.text = " ";
        TXT.DOText(textSTR, tweenTime)
            .SetEase(ease)
            .OnComplete(() =>
            {
                completeAction?.Invoke();
            });
    }





    
} // ███ END OF CLASS ████████████████████████████████████████████████████████████████████████████████████████████████
