using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toddler : Baby
{
    public override void Eat()
    {
        Debug.Log("Eat");
    }

    public override void Move()
    {
        Debug.Log("Walk");
    }
}
