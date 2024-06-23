using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    // Start is called before the first frame update
    public virtual void Start()
    {
        Breath();
        Eat();
    }

    public virtual void Breath() 
    {
        Debug.Log("Breath");
    }

    public virtual void Eat()
    {
        Debug.Log("Eat");
    }
}
