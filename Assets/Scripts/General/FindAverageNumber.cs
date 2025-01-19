using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindAverageNumber : MonoBehaviour
{
    public List<float> numbersList;
    public float totalNumber;
    public float averageNumber;
    // Start is called before the first frame update
    void Start()
    {
        numbersList.Add(4);
        numbersList.Add(6);
        numbersList.Add(2);
        numbersList.Add(15);

        for (int i = 0; i < numbersList.Count; i++)
        {
            totalNumber += numbersList[i];
        }

        averageNumber = totalNumber / numbersList.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
