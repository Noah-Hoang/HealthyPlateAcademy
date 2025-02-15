using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TransformUndoSystem : MonoBehaviour
{
    //make a script that allows to save state of transform and when undo pressed bring back to preivous state
    //save state button passes in transform
    //undo button returns to last transform

    // Start is called before the first frame update

    public struct TransformStruct
    {
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 scale;
    }

    public Transform inputTransform;
    public Stack<TransformStruct> transformStack;
    void Start()
    {
        transformStack = new Stack<TransformStruct>();
        SaveButtonCM();
    }

    [ContextMenu("SaveButton")]
    public void SaveButtonCM()
    {
        SaveButton(inputTransform);
    }

    public void SaveButton(Transform inputTransform)
    {
        TransformStruct transformStruct = new TransformStruct();
        transformStruct.position = inputTransform.position;
        transformStruct.rotation = inputTransform.eulerAngles;
        transformStruct.scale = inputTransform.localScale;
        transformStack.Push(transformStruct);
    }

    [ContextMenu("Undo Transform")]
    public void UndoButtonCM()
    {
        UndoButton(inputTransform);
    }

    public void UndoButton(Transform inputTransform)
    {
        TransformStruct tempStruct;
        if (transformStack.Count == 1)
        {
            tempStruct = transformStack.Peek();
        }
        else
        {
            tempStruct = transformStack.Pop();
        }
        inputTransform.position = tempStruct.position;
        inputTransform.eulerAngles = tempStruct.rotation;
        inputTransform.localScale = tempStruct.scale;
    }
}
