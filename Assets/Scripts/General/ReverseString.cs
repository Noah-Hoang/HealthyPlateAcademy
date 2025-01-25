using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseString : MonoBehaviour
{
    public string testString;
    // Start is called before the first frame update
    void Start()
    {
        if (testString == "")
        {
            return;
        }
        ReversesString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReversesString()
    {
        for (int i = testString.Length - 1; i >= 0; i--)
        {
            Debug.Log(testString[i]);
        }

        
    }
}
