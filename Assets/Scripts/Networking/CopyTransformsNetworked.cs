using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

//TOD: Use transform reference and copy its position and rotation
public class CopyTransformsNetworked : NetworkBehaviour
{
    public Transform targetTransform;

    public override void FixedUpdateNetwork()
    {
        base.FixedUpdateNetwork();
        //transform is the NetworkedHand and targetTransform is the corresponding controller
        transform.position = targetTransform.position;
        transform.rotation = targetTransform.rotation;
    }
}