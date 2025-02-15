using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextGreaterElement : MonoBehaviour
{
    // Start is called before the first frame update
    //Set of numbers in an array
    //return true or false if next number is greater and debugs all
    //1 2 1 4 3 5; returns: false, true, false, true, false

    public int inputNumber;
    public Queue<int> numbersQueue;
    void Start()
    {
        numbersQueue = new Queue<int>();
    }

    public bool GreatestNextElemet()
    {
       
    }
}
