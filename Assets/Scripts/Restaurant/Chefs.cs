using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chefs : Staff
{
    public void Awake() 
    {
        wage = 23.35f;
        workingHours = 8;
    }

    public void PrepareFood(Orders order, Waiters waiter)
    {
        TimerCoroutine(order, waiter);
        Debug.Log("[Chef.cs]Preapared" + "" + order + "served by" + "" + waiter);
    }

    public IEnumerator TimerCoroutine(Orders order, Waiters waiter)
    {
        yield return new WaitForSeconds(3.0f);
        waiter.ServeFood(order);
        Debug.Log("[Chef.cs]" + waiter + "serving" + "" + order);
    }
}
