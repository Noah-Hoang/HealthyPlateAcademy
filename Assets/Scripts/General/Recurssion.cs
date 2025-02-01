using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recurssion : MonoBehaviour
{
    public int startingNumber;
    public int totalNumber;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i > startingNumber; i++)
        {
            totalNumber += i;
        }
        Sum(startingNumber);
    }

    int Sum(int n)
    {
        // Base case: if n is 0, return 0
        if (n == 0)
        {
            return 0;
        }

        // Recursive case: n + the sum of numbers from 1 to n-1
        return n + Sum(n - 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
