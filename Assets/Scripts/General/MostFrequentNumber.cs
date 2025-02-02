using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostFrequentNumber : MonoBehaviour
{
    public int[] numbersArray;

    //Go through array and store most frequent number in mfn
    //Store the amount of times a number appears in the array (variable; currentHighestFrequency)
    //Store the number that appears the most (variable; mfn)
    //if statement to check whether other numbers in array appear have a higher frequency than our currentHighestFrequency
    //if they do, replace mfn and currentHighestFrequency with new numbers

    // go through each number in the array and check to see how many times each number appears. We will check by comparing our current number (i) with every otehr number in the for loop (j)
    void Start()
    {
        int currentHighestFrequency = 0;
        int mfn;
        for (int i = 0; i < numbersArray.Length; i++)
        {
            int currentFrequency = 0;

            for (int j = 0; j < numbersArray.Length; j++)
            {
                if (numbersArray[i] == numbersArray[j])
                {
                    currentFrequency++;
                }               
            }

            if (currentHighestFrequency < currentFrequency)
            {
                currentHighestFrequency = currentFrequency;
                mfn = numbersArray[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
