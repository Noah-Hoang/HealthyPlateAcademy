using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : Human
{
    public override void Start()
    {
        base.Start();
        Cry();
        Move();
    }

    public override void Eat()
    {
        Debug.Log("Drink milk");
    }

    public virtual void Cry()
    {
        Debug.Log("Cry");
    }

    public virtual void Move()
    {
        Debug.Log("Crawl");
    }
}
