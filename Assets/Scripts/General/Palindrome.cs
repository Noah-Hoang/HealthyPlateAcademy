using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palindrome : MonoBehaviour
{
    // Set up variable
    // Store each character of string in a list
    // Reverse for loop list and store reversed characters in new list then check if both lists are equal

    public string testString;
    public List<char> characterList;
    public List<char> reverseCharacterList;
    public bool palindrome;
    void Start()
    {
        string reverseString = "";
        for (int i = testString.Length - 1; i >= 0; i--)
        {
            reverseString += testString[i];
        }

        if (reverseString == testString)
        {
            palindrome = true;
        }
        Debug.Log(palindrome);
        return;
        for (int i = 0; i < testString.Length; i++)
        {
            characterList.Add(testString[i]);
        }

        for (int i = characterList.Count - 1; i >= 0; i--)
        {
            reverseCharacterList.Add(characterList[i]);
        }

        for (int i = 0; i < characterList.Count; i++)
        {
            if (characterList[i] == reverseCharacterList[i])
            {
                palindrome = true;
            }
            else if (characterList[i] != reverseCharacterList[i])
            {
                palindrome = false;
                Debug.Log(palindrome);
                return;
            }
        }
        Debug.Log(palindrome);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
