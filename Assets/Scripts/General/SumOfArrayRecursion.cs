using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumOfArrayRecursion : MonoBehaviour
{
    public int[] numbersArray;
    public int index;

    //call a method that passes in the array, it should find the sum of the numbers in taht array using recurison
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //
    public int Sum(int[] n, int i)
    {
        if (i == 0)
        {
            return n[0];
        }

        return n[i] + Sum(n,i - 1);
    }

    public int Sum2(int[] n, int i)
    {
        if (i == n.Length)
        {
            return 0;
        }

        return n[i] + Sum(n, i + 1);
    }
}
