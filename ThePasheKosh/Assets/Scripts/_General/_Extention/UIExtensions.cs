using TMPro;
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

}//EndClasssss
