using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix : MonoBehaviour
{
    static int row = 10; 
    static int column = 10;
    int[,] matrix;

    const int one = 1;
    const int zero = 0;
    List<int[]> Islands = new List<int[]>(); 
    private void Start()
    {
        InitMatrix();
    }

    void InitMatrix()
    {
        matrix = new int[row, column];
    }


    void FindAllIslandsInScene()
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                if (matrix[i, j] == one)
                {
                    //Add index to the list

                    //for side of matrix
                    for (int k = 1; j + k < row; k++)
                    {
                        if (matrix[i, j + k] == one)
                        {
                            //Add index to the list
                        }
                    }

                }
            }
        }
    }//IslandFinder


}//EndClassss
