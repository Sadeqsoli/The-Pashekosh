using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : Singleton<DataHolder>
{
    public static bool isSplashed { get; set; } = false;

}
