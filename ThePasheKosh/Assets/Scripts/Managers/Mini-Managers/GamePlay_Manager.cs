using UnityEngine;
using TMPro;
using RTLTMPro;

public class GamePlay_Manager : MonoBehaviour
{
    #region Properties

    #endregion

    #region Fields
    [SerializeField] RTLTextMeshPro _ScoreTXT, _PillTXT, _LevelTXT, _TimeTXT;
     int score, pill, level, time;
    #endregion

    #region Public Methods
    #endregion


    #region Private Methods
    void Start()
    {
        _ScoreTXT.text = score.ToString();
        _PillTXT.text = pill.ToString();
        _LevelTXT.text = level.ToString();
        _TimeTXT.text = time.ToString();

    }//Startttttt





    void Update()
    {


    }//Updateeeee
    #endregion
}//EndClasssss/SadeQ
