using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextGreaterElement : MonoBehaviour
{
    // Start is called before the first frame update
    //Set of numbers in an array
    //return true or false if next number is greater and debugs all
    //1 2 1 4 3 5; returns: false, true, false, true, false

    public int[] inputNumbers;
    public Queue<int> numbersQueue;
    void Start()
    {
        numbersQueue = new Queue<int>();
        EnterNumbers();
        DebugAll();
    }

    [ContextMenu("Enter Numbers")]
    public void EnterNumbers()
    {
        numbersQueue.Clear();
        for (int i = 0; i < inputNumbers.Length; i++)
        {
            numbersQueue.Enqueue(inputNumbers[i]);
        }
    }

    public bool GreatestNextElemet()
    {
        if (numbersQueue.Dequeue() < numbersQueue.Peek())
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void DebugAll()
    {
        while (numbersQueue.Count > 1)
        {
            Debug.Log(GreatestNextElemet());
        }
    }
}
