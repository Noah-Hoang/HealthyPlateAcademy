using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntegerNode : BaseNode
{
    public int value;

    public IntegerNode(int tempValue, BaseNode tempNextNode = null) : base(tempNextNode)
    {
        value = tempValue;
    }

}
