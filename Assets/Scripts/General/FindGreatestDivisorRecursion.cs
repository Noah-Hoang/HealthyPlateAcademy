using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FindGreatestDivisorRecursion : MonoBehaviour
{
    public int firstNumber;
    public int secondNumber;
    public int divisor;
    private int gcf = 1;
    //48 18
    // Start is called before the first frame update
    void Start()
    {
        //divisor is when you start finding the gcf
        Sum(firstNumber, secondNumber, divisor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Sum(int n, int m, int d)
    {
        if (d > n || d > m)
        {
            return gcf;
        }

        if (n%d == 0 && m%d == 0)
        {
            gcf = d;
        }

        return Sum(n, m, d + 1);
    }
}
