using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortNumbers : MonoBehaviour
{
    public List<float> numbersList;
    public float totalNumber;
    // Start is called before the first frame update
    void Start()
    {
        numbersList.Add(4); // now 2
        numbersList.Add(6); // now 4
        numbersList.Add(2); // Now 6
        numbersList.Add(15);// now 13
        numbersList.Add(13); // now 15

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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
