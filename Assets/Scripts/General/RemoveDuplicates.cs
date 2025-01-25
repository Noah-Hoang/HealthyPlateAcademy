using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveDuplicates : MonoBehaviour
{
    public List<int> numbersList;
    public bool isDuplicate;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numbersList.Count; i++)
        {
            isDuplicate = false;
            for (int j = 0; j < numbersList.Count; j++)
            {
                if (i == j)
                {
                    continue;
                }
                if (numbersList[i] == numbersList[j])
                {
                    isDuplicate = true;
                }
            }

            if (!isDuplicate)
            {
                Debug.Log(numbersList[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
