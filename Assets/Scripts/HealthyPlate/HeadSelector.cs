using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class HeadSelector : MonoBehaviour
{
    public int index;
    public List<GameObject> heads;
    public Transform headDisplay;

    public void OnPressed()
    {
        HeadDisplay.Instance.index = index;
    }

    public void OnRightPressed()
    {
        index++;

        if (index >= heads.Count)
        {
            index = 0;
        }

        if (headDisplay.childCount != 0)
        {
            Destroy(headDisplay.GetChild(0).gameObject);
        }
        GameObject tempObject = Instantiate(heads[index], headDisplay);
        tempObject.transform.localPosition = Vector3.zero;
        tempObject.transform.localRotation = Quaternion.identity;
    }

    public void OnLeftPressed()
    {
        index--;

        if (index < 0)
        {
            index = heads.Count - 1;
        }

        if (headDisplay.childCount != 0)
        {
            Destroy(headDisplay.GetChild(0).gameObject);
        }
        GameObject tempObject = Instantiate(heads[index], headDisplay);
        tempObject.transform.localPosition = Vector3.zero;
        tempObject.transform.localRotation = Quaternion.identity;
    }
}
