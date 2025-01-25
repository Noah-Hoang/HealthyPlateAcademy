using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintOdds : MonoBehaviour
{
    public List<int> numbersList;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < 51; i++)
        {
            numbersList.Add(i);
        }
        //FindOddNumberMethod1();
    }

    // Update is called once per frame
    public void FindOddNumberMethod1()
    {
        for (int i = 0; i < numbersList.Count; i++)
        {
            int remainder = numbersList[i] % 2;
            if (remainder == 1)
            {
                Debug.Log(numbersList[i]);
            }
        }
    }

    public void FindOddNumberMethod2()
    {
        for (int i = 1; i <= 49; i += 2)
        {
            Debug.Log(i);
        }
    }
}
