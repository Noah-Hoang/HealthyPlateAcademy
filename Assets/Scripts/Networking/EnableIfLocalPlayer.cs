using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class EnableIfLocalPlayer : NetworkBehaviour
{
    public List<GameObject> objectsToEnable;

    public override void Spawned()
    {
        base.Spawned();

        if (Runner.LocalPlayer == Object.StateAuthority)
        {
            foreach (GameObject obj in objectsToEnable)
            {
                obj.SetActive(true);
            }
        }
    }
}
