using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armstrong : MonoBehaviour
{
    //153 = 1^3 + 5^3 + 3^3
    // Start is called before the first frame update

    public int number;
    public string numberString;
    public int totalNumber;
    void Start()
    {
        int testNumber = 3;
        string testString = testNumber.ToString();
        Debug.Log(CheckArmstrong(number));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckArmstrong(int inputNumber)
    {
        //int power = inputNumber.ToString().Length
        int power;
        numberString = inputNumber.ToString();
        power = numberString.Length;
        Debug.Log(power);

        for (int i = 0; i < numberString.Length; i++)
        {
            int currentProduct = 1;
            for (int j = 0; j < power; j++)
            {
                Debug.Log(numberString[i]);
                currentProduct *= numberString[i] - '0';
            }
            Debug.Log(currentProduct);
            totalNumber += currentProduct;
            Debug.Log(totalNumber);

        }

        if (totalNumber == inputNumber)
        {
            return true;
        }
        return false;
    }
}
