using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseStringStack : MonoBehaviour
{
    //Make a stack of char 
    //Inspector string
    //Mehtod that reverses that string with stack
    // Start is called before the first frame update

    public string inputString;
    public Stack<char> charStack;

    private void Start()
    {
        charStack = new Stack<char>();
    }

    [ContextMenu("Reverse String")]
    public void RevereStringContextMenu()
    {
        ReverseString(inputString);
    }

    public void ReverseString(string input)
    {
        string reversedString = "";

        for (int i = 0; i < inputString.Length; i++)
        {
            charStack.Push(inputString[i]);
        }

        for (int i = 0; i < inputString.Length; i++)
        {
            reversedString += charStack.Pop();
        }

        Debug.Log(reversedString);
    }
}
