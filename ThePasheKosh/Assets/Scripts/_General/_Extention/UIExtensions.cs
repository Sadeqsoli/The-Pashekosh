using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public static class UIExtensions 
{
    public static void ChangeListener(this Button button, UnityAction currentAction)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(currentAction);
    }
    public static void ChangeListener(this Button button, UnityAction lastAction, UnityAction currentAction)
    {
        button.onClick.RemoveListener(lastAction);
        button.onClick.AddListener(currentAction);
    }

    public static void ChangeListener(this Toggle toggle, UnityAction<bool> currentAction)
    {
        toggle.onValueChanged.RemoveAllListeners();
        toggle.onValueChanged.AddListener(currentAction);
    }
    public static void ChangeListener(this Toggle toggle, UnityAction<bool> lastAction, UnityAction<bool> currentAction)
    {
        toggle.onValueChanged.RemoveListener(lastAction);
        toggle.onValueChanged.AddListener(currentAction);
    }

    public static void ChangeListener(this TMP_InputField tmp_input, UnityAction<string> currentAction)
    {
        tmp_input.onValueChanged.RemoveAllListeners();
        tmp_input.onValueChanged.AddListener(currentAction);
    }
    public static void ChangeListener(TMP_InputField tmp_input, UnityAction<string> lastAction, UnityAction<string> currentAction)
    {
        tmp_input.onValueChanged.RemoveListener(lastAction);
        tmp_input.onValueChanged.AddListener(currentAction);
    }

    public static void SnapTo(this ScrollRect scrollRect, RectTransform parentTR, RectTransform target, UnityAction OnComplete = null)
    {
        Canvas.ForceUpdateCanvases();
        parentTR.anchoredPosition =
        (Vector2)scrollRect.transform.InverseTransformPoint(parentTR.position)
        - (Vector2)scrollRect.transform.InverseTransformPoint(target.position);

        OnComplete?.Invoke();
    }




}//EndClasssss
