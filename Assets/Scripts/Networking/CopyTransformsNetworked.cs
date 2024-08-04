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

        transform.position = targetTransform.position;
        transform.rotation = targetTransform.rotation;
    }
}