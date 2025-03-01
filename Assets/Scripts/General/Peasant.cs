using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peasent : MonoBehaviour
{
    [ContextMenu ("praise")]
    public void Praise()
    {
        Debug.Log("All hail king " + King.Instance.gameObject.name);
    }
}