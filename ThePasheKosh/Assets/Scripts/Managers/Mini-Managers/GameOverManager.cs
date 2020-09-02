using UnityEngine;
using UnityEngine.UI;
using TMPro;
using RTLTMPro;
using System.Collections;
using System.Collections.Generic;

public class GameOverManager : MonoBehaviour
{
    #region Properties

    #endregion

    #region Fields
    [SerializeField] RTLTextMeshPro _LevelTXT, __ScoreTXT, _TimeTXT, _PillTXT;
    #endregion

    #region Public Methods
    #endregion


    #region Private Methods
    void Start()
    {
        _LevelTXT.text = LevelRepo.GetLevel().ToString();
        __ScoreTXT.text = ScoreRepo.GetHighScore().ToString();
        _TimeTXT.text = TimeRepo.GetHighTime().ToString();
        _PillTXT.text = PillRepo.GetPill().ToString();
    }//Startttttt





    void Update()
    {


    }//Updateeeee
    #endregion
}//EndClasssss/SadeQ
