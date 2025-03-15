using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript_1 : MonoBehaviour
{
    public static int testInt;
    void Start()
    {
        Add(3, 2);
        Add(3.0f, 2.0f);
        Add(3.0f, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float Add(float first, float second)
    {
        return first + second;
    }

    public int Add(int first, int second)
    {
        return first + second;
    }
}
