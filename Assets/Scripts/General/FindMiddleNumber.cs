using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMiddleNumber : MonoBehaviour
{
    //Find the middle number, have boolean option, if no middle number, find highest or lowest middle number

    public List<float> numbersList;
    public float totalNumber;
    public float middleNumber;
    public bool useLower;

    void Start()
    {
        numbersList.Add(4); // now 2
        numbersList.Add(6); // now 4
        numbersList.Add(2); // Now 6
        numbersList.Add(15);// now 13
        numbersList.Add(13); // now 15
        numbersList.Add(17);

        //float numberHolder = numbersList[0];
        //numbersList[0] = numbersList[1];
        //numbersList[1] = numberHolder;

        for (int i = 0; i < numbersList.Count; i++)
        {
            float lowestNumber = Mathf.Infinity;
            for (int j = i; j < numbersList.Count; j++)
            {
                if (numbersList[j] < lowestNumber)
                {
                    lowestNumber = numbersList[j];
                    float numberHolder = numbersList[i];
                    numbersList[i] = lowestNumber;
                    numbersList[j] = numberHolder;
                }
            }
        }

        int remainder = numbersList.Count % 2;
        if (remainder == 1)
        {
            int middleIndex = (numbersList.Count + 1) / 2;
            middleNumber = numbersList[middleIndex];
        }
        else if (useLower)
        {
            int lowerIndex = (numbersList.Count / 2) - 1;
            middleNumber = numbersList[lowerIndex];
        }
        else if (!useLower)
        {
            int higherIndex = numbersList.Count / 2;
            middleNumber = numbersList[higherIndex];
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
