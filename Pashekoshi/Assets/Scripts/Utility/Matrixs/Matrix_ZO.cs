using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//using this class for showing matrix in the inspector
[System.Serializable]
public class Matrix_ZO
{
    [System.Serializable]
    public struct rowData_ZO
    {
        public int[] row_ZO;
    }
    public rowData_ZO[] rows_ZO = new rowData_ZO[14]; //Grid of 7x7

}//EndCalssss/SadeQ