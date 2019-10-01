using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour
{
    /// <summary>
    ///  Return <int> Random Value
    /// </summary>
    /// <param name="min">min value </param>
    /// <param name="max"> max value</param>
    /// <returns></returns>
   public static int RandomInt(int min,int max)
    {
        int val = Random.Range(min, max);
        return val;
    }

}
