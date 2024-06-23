using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInheritanceExample : Vehicle
    //inherits from the Vehicle class
{
    public override void TurnOn()
    {
        base.TurnOff();
        //grabs the TurnOff method from the Vehicle class using base.TurnOff
        //base. allows you to use the methods from the base class
        Looks();
        //Since there is no base. in front of the Looks method here, it uses the Looks method from this class
        base.TurnOn();
        base.TurnOn();
        //debugs out to "Turning Car off" then "Turning Car off" again then "Turning Car On" twice.
    }

    public override void TurnOff()
    {
        //displays nothing unless there was base.TurnOff in this mehthod which would run the TurnOff method from the Vehicle class
    }

    public override void Looks()
    {
        base.TurnOff();
    }
}
