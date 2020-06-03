
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculator_Machine
{
    #region Properties
    #endregion
    #region Fields
    [SerializeField] Text Result, Operation;
    [SerializeField] InputField ipfnumber1, ipfnumber2;
    [SerializeField] Button add;

    [SerializeField] float varA, varB, varC;
    #endregion
    #region Public Methods
    public void Addition()
    {

        varA = float.Parse(ipfnumber1.text);
        varB = float.Parse(ipfnumber2.text);

        float varAdd = varA + varB;

        Operation.text = "+";
        Result.text = varAdd.ToString();
    }

    public void Subtraction()
    {

        varA = float.Parse(ipfnumber1.text);
        varB = float.Parse(ipfnumber2.text);

        float varSub = varA - varB;

        Debug.Log("Result= " + varSub.ToString());

        Operation.text = "-";
        Result.text = varSub.ToString();
    }

    public void Multiplication()
    {

        varA = float.Parse(ipfnumber1.text);
        varB = float.Parse(ipfnumber2.text);

        float varMul = varA * varB;

        Debug.Log("Result= " + varMul.ToString());

        Operation.text = "times";
        Result.text = varMul.ToString();
    }

    public void Division()
    {

        varA = float.Parse(ipfnumber1.text);
        varB = float.Parse(ipfnumber2.text);

        float varDiv = varA / varB;

        Debug.Log("Result= " + varDiv.ToString());

        Operation.text = "by";
        Result.text = varDiv.ToString();
    }

    public void PercentInput()
    {
        varA = float.Parse(ipfnumber1.text);
        varB = float.Parse(ipfnumber2.text);

        varC = PercentOutput(varA, varB);

        Operation.text = "is Percentage of";
        Result.text = varC.ToString() + "%";
    }
    #endregion


    #region Private Methods
    private float PercentOutput(float varPerA, float varPerB)
    {
        float varPer = varPerB * 100 / varPerA;

        return (varPer);
    }
    #endregion

}//EndClassss/SadeQ