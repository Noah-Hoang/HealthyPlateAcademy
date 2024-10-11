using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class HeadDisplay : NetworkBehaviour
{
    public static HeadDisplay Instance { get; private set; }

    //Whenever the variable changes, call the method inside
    [Networked, OnChangedRender(nameof(ChangeHead))]
    public int index { get; set; }

    public List<GameObject> heads;
    public Transform headDisplay;

    public override void Spawned()
    {
        base.Spawned();

        //For your character, make this instance of this script into a singleton
        if (Object.HasStateAuthority)
        {
            if (Instance != null)
            {
                Destroy(this.gameObject);
                return;

            }
            Instance = this;
        }

        ChangeHead();
    }

    public void ChangeHead()
    {
        //Checks to see if it is your character head
        if (Object.HasStateAuthority)
        {
            return;
        }
        //If there is already a head when the button is clicked, destroy it
        if (headDisplay.childCount != 0)
        {
            Destroy(headDisplay.GetChild(0).gameObject);
        }
        GameObject tempObject = Instantiate(heads[index], headDisplay);
        tempObject.transform.localPosition = Vector3.zero;
        tempObject.transform.localRotation = Quaternion.identity;
    }
}