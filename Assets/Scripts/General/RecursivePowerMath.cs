using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecursivePowerMath : MonoBehaviour
{
    public int baseNumber;
    public int exponent;

    //start calls method that passes in both numbers and should find the total usign recursion
    // Start is called before the first frame update
    void Start()
    {
        Sum(baseNumber, exponent);
    }

    // Update is called once per frame
    int Sum(int n,int m)
    {
        if (m == 1)
        {
            return n;
        }


        // Recursive case: n + the sum of numbers from 1 to n-1
        return n * Sum(n,m - 1);
    }
}
