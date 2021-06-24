using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening.Core;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public enum TTScale { XScaleUp, XScaleDown, ScaleUp, ScaleDown, YScaleUp, YScaleDown, ShakeIt }
public enum TTRotate { XRotate, YRotate, ZRotate, ShakeRot }
public enum TTMove { XMove, Move, YMove, ShakePos }
public enum TTIColoring { IMGFadeIn, IMGFadeOut , Coloring }
public enum TTTFader { TXTFadeIn, TXTFadeOut }
public enum TTTColoring { SimpleColoring, GlowColoring }

public static class CTween
{
    static Vector3 zeroX = new Vector3(0, 1, 1);
    static Vector3 zeroY = new Vector3(1, 0, 1);


    //To Scale.
    public static Tweener Scaler(this Transform t, TTScale tweenScaler, UnityAction completeAction = null,
        float tweenTime = 1f, Ease ease = Ease.InOutExpo)
    {
        Tweener tweener = null;
        switch (tweenScaler)
        {
            //Scaling up in X vector.
            case TTScale.XScaleUp:
                t.localScale = zeroX;
                t.gameObject.SetActive(true);
                tweener = t.DOScaleX(1, tweenTime)
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
                tweener = t.DOScale(Vector3.one, tweenTime)
                    .SetEase(ease)
                    .OnComplete(() =>
                    {
                        completeAction?.Invoke();
                    });
                break;

            //Scaling Down in X , Y vector.
            case TTScale.ScaleDown:

                tweener = t.DOScale(Vector3.zero, tweenTime)
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
                tweener = t.DOScaleY(1, tweenTime)
                    .SetEase(ease)
                    .OnComplete(() =>
                    {
                        completeAction?.Invoke();
                    });
                break;

            //Scaling Down in Y vector.
            case TTScale.YScaleDown:
                t.localScale = Vector3.one;
                tweener = t.DOScaleY(0, tweenTime)
                    .SetEase(ease)
                    .OnComplete(() =>
                    {
                        t.gameObject.SetActive(false);
                        completeAction?.Invoke();
                    });
                break;

            //Shake Scaling in every Direction
            case TTScale.ShakeIt:
                tweener = t.DOShakeScale(1f, 0.5f, 5)
                    .SetEase(ease)
                    .OnComplete(() =>
                    {
                        completeAction?.Invoke();
                    });
                break;
        }
        return tweener;
    }


    //To Rotate.
    public static Tweener Rotater(this Transform t, TTRotate tweenScaler, float endValue, UnityAction completeAction = null,
        float tweenTime = 1f, Ease ease = Ease.Unset)
    {
        Tweener tweener = null;
        switch (tweenScaler)
        {
            //Rotating in X vector.
            case TTRotate.XRotate:
                Vector3 xRot = new Vector3(endValue, 0, 0);
                t.gameObject.SetActive(true);
                tweener = t.DORotate(xRot, tweenTime)
                    .SetEase(ease)
                    .OnComplete(() =>
                    {
                        completeAction?.Invoke();
                    });
                break;

            //Rotating in Y vector.
            case TTRotate.YRotate:
                Vector3 yRot = new Vector3(0, endValue, 0);
                t.gameObject.SetActive(true);
                tweener = t.DORotate(yRot, tweenTime)
                    .SetEase(ease)
                    .OnComplete(() =>
                    {
                        completeAction?.Invoke();
                    });
                break;

            //Rotating in Z vector.
            case TTRotate.ZRotate:
                Vector3 zRot = new Vector3(0, 0, endValue);
                t.gameObject.SetActive(true);
                tweener = t.DORotate(zRot, tweenTime)
                    .SetEase(ease)
                    .OnComplete(() =>
                    {
                        completeAction?.Invoke();
                    });
                break;

            //Shake Rotation in every Direction
            case TTRotate.ShakeRot:

                tweener = t.DOShakeRotation(1f, 0.5f, 5)
                    .SetEase(ease)
                    .OnComplete(() =>
                    {
                        completeAction?.Invoke();
                    });
                break;
        }
        return tweener;
    }


    //To Move.
    public static Tweener Mover(this Transform t, TTMove tweenMover, UnityAction completeAction = null,
        float tweenTime = 1f, Ease ease = Ease.InOutExpo)
    {
        Tweener tweener = null;
        switch (tweenMover)
        {
            //Scaling up in X vector.
            case TTMove.XMove:
                t.localScale = zeroX;
                t.gameObject.SetActive(true);
                tweener = t.DOScaleX(1, tweenTime)
                    .SetEase(ease)
                    .OnComplete(() =>
                    {
                        completeAction?.Invoke();
                    });
                break;

            //Scaling Down in X vector.
            case TTMove.YMove:
                t.localScale = Vector3.one;
                tweener = t.DOScaleX(0, tweenTime)
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
                tweener = t.DOScale(Vector3.one, tweenTime)
                    .SetEase(ease)
                    .OnComplete(() =>
                    {
                        completeAction?.Invoke();
                    });
                break;

            //Shake Position in every Direction
            case TTMove.ShakePos:
                tweener = t.DOShakePosition(1f, 0.5f, 5)
                    .SetEase(ease)
                    .OnComplete(() =>
                    {
                        completeAction?.Invoke();
                    });
                break;


        }
        return tweener ;
    }





    //For float numbers.
    public static Tweener ToFloat(float starter, float endValue, float tweenTime = 1f,
        UnityAction updateAction = null, UnityAction completeAction = null, Ease ease = Ease.InOutExpo)
    {
        Tweener tweener = null;
        tweener = DOTween.To(() => starter, x => starter = x, endValue, tweenTime)
            .SetEase(ease)
            .OnUpdate(() => { updateAction?.Invoke(); })
            .OnComplete(() => { completeAction?.Invoke(); });

        return tweener;
    }


    //For Int numbers.
    public static Tweener ToInt(int starter, int endValue, float tweenTime = 1f,
        UnityAction updateAction = null, UnityAction completeAction = null, Ease ease = Ease.InOutExpo)
    {
        Tweener tweener = null;
        tweener = DOTween.To(() => starter, x => starter = x, endValue, tweenTime)
            .SetEase(ease)
            .OnUpdate(() => { updateAction?.Invoke(); })
            .OnComplete(() => { completeAction?.Invoke(); });
        return tweener;
    }

    //For Vector3 numbers.
    public static Tweener ToVector3(Vector3 starter, Vector3 endValue, float tweenTime = 1f,
        UnityAction updateAction = null, UnityAction completeAction = null, Ease ease = Ease.InOutExpo)
    {
        Tweener tweener = null;
        tweener = DOTween.To(() => starter, x => starter = x, endValue, tweenTime)
            .SetEase(ease)
            .OnUpdate(() => { updateAction?.Invoke(); })
            .OnComplete(() => { completeAction?.Invoke(); });
        return tweener;
    }



    //To Do a Scuencer Animation
    public static void Sequencer(List<Tweener> tweeners)
    {
        Sequence sequence = DOTween.Sequence();
        int tweenerChilds = tweeners.Count;
        for (int i = 0; i < tweenerChilds; i++)
        {
            sequence.Append(tweeners[i]);
        }
        sequence.Play();
    }
    //To Do a Scuencer Animation
    public static void Sequencer(Tweener[] tweeners)
    {
        Sequence sequence = DOTween.Sequence();
        int tweenerChilds = tweeners.Length;
        for (int i = 0; i < tweenerChilds; i++)
        {
            sequence.Append(tweeners[i]);
        }
        sequence.Play();
    }



    //Fade In Fade Out...
    public static void FadeInFadeOut(this CanvasGroup canvasGroup)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(canvasGroup.DOFade(1.0f, 0.2f));
        sequence.Append(canvasGroup.DOFade(0.0f, 1.5f));
        sequence.Play();

    }






    //To Fade Image.
    public static Tweener Imager(this Image IMG, TTIColoring tweenFader, UnityAction completeAction = null, Color color = default,
        float tweenTime = 1f, Ease ease = Ease.InOutExpo)
    {
        Tweener tweener = null;
        switch (tweenFader)
        {
            case TTIColoring.IMGFadeIn:
                tweener = IMG.DOFade(1f, tweenTime)
            .SetEase(ease)
            .OnComplete(() =>
            {
                completeAction?.Invoke();
            });
                break;
            case TTIColoring.IMGFadeOut:
                tweener = IMG.DOFade(0f, tweenTime)
            .SetEase(ease)
            .OnComplete(() =>
            {
                completeAction?.Invoke();
            });
                break;
            case TTIColoring.Coloring:
                tweener = IMG.DOColor(color, tweenTime)
            .SetEase(ease)
            .OnComplete(() =>
            {
                completeAction?.Invoke();
            });
                break;
        }
        return tweener;
    }

    //To Color Image.
    public static void IMGGradientColor(this Image IMG, Gradient gradient = default,
        UnityAction completeAction = null, float tweenTime = 1f, Ease ease = Ease.InOutExpo)
    {
         IMG.DOGradientColor(gradient, tweenTime)
            .SetEase(ease)
            .OnComplete(() =>
            {
                completeAction?.Invoke();
            });
    }
    //To Fill Image.
    public static Tweener IMGFiller(this Image IMG, float filAmount, UnityAction updateAction = null,
        UnityAction completeAction = null, float tweenTime = 1f, Ease ease = Ease.InOutExpo)
    {
        Tweener tweener = null;
        tweener = IMG.DOFillAmount(filAmount, tweenTime)
            .SetEase(ease)
            .OnUpdate(() =>
            {
                updateAction?.Invoke();
            })
            .OnComplete(() =>
            {
                completeAction?.Invoke();
            });
        return tweener;
    }




    //To Fade TextmeshPro.
    public static Tweener TXTFader(this TextMeshProUGUI TXT, TTTFader tweenFader, UnityAction completeAction = null,
        float tweenTime = 1f, Ease ease = Ease.InOutExpo)
    {
        Tweener tweener = null;
        switch (tweenFader)
        {
            case TTTFader.TXTFadeIn:
                tweener = TXT.DOFade(1f, tweenTime)
            .SetEase(ease)
            .OnComplete(() =>
            {
                completeAction?.Invoke();
            });
                break;
            case TTTFader.TXTFadeOut:
                tweener = TXT.DOFade(0f, tweenTime)
            .SetEase(ease)
            .OnComplete(() =>
            {
                completeAction?.Invoke();
            });
                break;

        }
        return tweener;
    }

    //To Color TextmeshPro.
    public static Tweener TXTColoring(this TextMeshProUGUI TXT, TTTColoring tweenFader, Color color,
       UnityAction completeAction = null, float tweenTime = 1f, Ease ease = Ease.InOutExpo)
    {
        Tweener tweener = null;
        switch (tweenFader)
        {
            case TTTColoring.SimpleColoring:
                tweener = TXT.DOColor(color, tweenTime)
            .SetEase(ease)
            .OnComplete(() =>
            {
                completeAction?.Invoke();
            });
                break;
            case TTTColoring.GlowColoring:
                tweener = TXT.DOGlowColor(color, tweenTime)
            .SetEase(ease)
            .OnComplete(() =>
            {
                completeAction?.Invoke();
            });
                break;

        }
        return tweener;
    }

    //To Write in TextmeshPro.
    public static Tweener Texter(this TextMeshProUGUI TXT, string textSTR, UnityAction updateAction = null,
        UnityAction completeAction = null,
        float tweenTime = 1f, Ease ease = Ease.InOutExpo)
    {
        Tweener tweener = null;
        TXT.text = " ";
        tweener = TXT.DOText(textSTR, tweenTime)
            .SetEase(ease)
            .OnUpdate(() =>
            {
                updateAction?.Invoke();
            })
            .OnComplete(() =>
            {
                completeAction?.Invoke();
            });
        return tweener;
    }






} // ███ END OF CLASS ████████████████████████████████████████████████████████████████████████████████████████████████
