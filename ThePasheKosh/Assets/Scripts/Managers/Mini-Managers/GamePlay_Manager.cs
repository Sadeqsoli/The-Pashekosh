using UnityEngine;
using TMPro;
using RTLTMPro;

public class GamePlay_Manager : MonoBehaviour
{
    #region Properties

    #endregion

    #region Fields
    [SerializeField] RTLTextMeshPro _ScoreTXT, _PillTXT, _LevelTXT;
     int score, pill, level;
    #endregion

    #region Public Methods
    #endregion


    #region Private Methods
    void Start()
    {
        _ScoreTXT.text = score.ToString();
        _PillTXT.text = pill.ToString();
        _LevelTXT.text = level.ToString();

    }//Startttttt





    void Update()
    {


    }//Updateeeee
    #endregion
}//EndClasssss/SadeQ
