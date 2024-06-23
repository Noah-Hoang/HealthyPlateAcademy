using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInheritanceExample : Vehicle
{
    public override void TurnOn()
    {
        base.TurnOff();
        Looks();
        base.TurnOn();
        base.TurnOn();
    }

    public override void TurnOff()
    {
    }

    public override void Looks()
    {
        base.TurnOff();
    }
}
