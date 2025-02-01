using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostFrequentNumber : MonoBehaviour
{
    public int[] numbersArray;
    public int mfn;
    public int index;

    //Go through array and store most frequent number in mfn
    //Store the amount of times a number appears in the array (variable; currentHighestFrequency)
    //Store the number that appears the most (variable; mfn)
    //if statement to check whether other numbers in array appear have a higher frequency than our currentHighestFrequency
    //if they do, replace mfn and currentHighestFrequency with new numbers
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int MostFrequent(int[] n, int i)
    {
        if (i == numbersArray.Length)
        {
            return mfn;
        }



        return MostFrequent(n, i + 1);
    }
}
