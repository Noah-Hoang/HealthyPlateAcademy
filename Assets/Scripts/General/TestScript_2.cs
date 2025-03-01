using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript_2 : MonoBehaviour
{
    public static TestScript_2 instance;

    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("Test 1")]
    public void Test_1()
    {

    }
}
