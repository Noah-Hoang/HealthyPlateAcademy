using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindSecondLargest : MonoBehaviour
{
    public List<int> numbersList;
    // Start is called before the first frame update
    void Start()
    {

        if (numbersList.Count < 2)
        {
            Debug.Log("PUT MORE NUMBERSS");
            return;
        }

        //Goal 1: Sort the list
        //Make a for loop going through the list
        //Goal 2: Get the second to last index of the sorted list
        for (int i = 0; i < numbersList.Count; i++)
        {
            for (int j = i; j < numbersList.Count; j++)
            {
                if (numbersList[i] > numbersList[j])
                {
                    int swappedNumber = numbersList[i];
                    numbersList[i] = numbersList[j];
                    numbersList[j] = swappedNumber;
                }
            }
        }

        int biggestNumber = numbersList.Count - 1;
        // for loop 1. starting point 2. continues while [condition] 3. change i per iteration
        for (int i = numbersList.Count - 1; i >= 0; i--)
        {
            if (numbersList[i] < numbersList[biggestNumber])
            {
                Debug.Log (numbersList[i]);
                return;
            }
        }


        Debug.Log("HELLO");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
