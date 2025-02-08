using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using UnityEngine;

public class WordFrequencyCounterDict : MonoBehaviour
{
    //get input from inspector (string), string is sentence
    //Dictionary adds in every word and count the words
    // ex: Key: Hello ; Value: 2
    // Start is called before the first frame update

    public string inputString;
    public Dictionary<string, int> wordFrequencyDictionary;
    void Start()
    {
        // Normalize text: Convert to lowercase and remove punctuation
        inputString = inputString.ToLower();
        inputString = Regex.Replace(inputString, @"[^\w\s]", ""); // Remove punctuation

        // Split text into words
        string[] words = inputString.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        // "Hello world Hello Unity developers Unity is great"

        //Option 1
        for (int i = 0; i < words.Length; i++)
        {
            int wordAmount = 0;
            for (int j = i; j < words.Length; j++)
            {
                if (words[i] == words[j])
                {
                    wordAmount++;
                }
            }
            if (!wordFrequencyDictionary.ContainsKey(words[i]))
            {
                wordFrequencyDictionary.Add(words[i], wordAmount);
            }
            
        }

        //Option 2
        for (int i = 0; i < words.Length; i++)
        {
            if (wordFrequencyDictionary.ContainsKey(words[i]))
            {
                wordFrequencyDictionary[words[i]] = wordFrequencyDictionary[words[i]] + 1;
            }
            else
            {
                wordFrequencyDictionary.Add(words[i], 1);
            } 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
