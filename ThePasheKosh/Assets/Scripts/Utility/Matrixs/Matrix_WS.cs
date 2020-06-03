using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//using this class for showing matrix in the inspector
[System.Serializable]
public class Matrix_WS 
{
    [System.Serializable]
    public struct rowData_WS
    {
        public string[] row_WS;
    }
    public rowData_WS[] rows_WS = new rowData_WS[14]; //Grid of 7x7

}//EndCalssss/SadeQ

