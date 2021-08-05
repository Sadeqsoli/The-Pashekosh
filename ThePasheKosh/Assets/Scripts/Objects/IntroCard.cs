using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "InsectsIntro", menuName = "Intro Card")]
[System.Serializable]
public class IntroCard : ScriptableObject
{
    public string InsectName;
    [TextArea(5,20)]
    public string InsectDescription;
}
