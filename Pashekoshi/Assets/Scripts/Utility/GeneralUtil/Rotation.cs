using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rotation : MonoBehaviour
{
    #region public Variables
    public Vector3 rotate;
    #endregion

    #region Private Variables

    #endregion

    #region Public Methods
    #endregion


    #region Private Methods
    void Start()
    {

    }//Startttttt







    void Update()
    {
        transform.Rotate(rotate.x, rotate.y, rotate.z);

    }//Updateeeee
    #endregion
}//EndClassss/SadeQ
