using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringCompression : MonoBehaviour
{
    public string testString;
    public int letterAmount;
    public string compressedString;
    //"aabbbaacc" = "a2b3a2c2"
    // Start is called before the first frame update
    void Start()
    {
        CompressString(testString);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void CompressString(string inputString)
    {
        string previousLetter = "";
        for (int i = 0; i < inputString.Length; i++)
        {
            letterAmount = 0;
            if (inputString[i].ToString() == previousLetter)
            {
                continue;
            }
            else
            {
                previousLetter = inputString[i].ToString();
            }

            for (int j = i; j < inputString.Length; j++)
            {
                if (inputString[i] == inputString[j])
                {
                    letterAmount++;
                }
                else
                {
                    break;
                }
            }

            compressedString += inputString[i] + letterAmount.ToString();
        }
    }
}
