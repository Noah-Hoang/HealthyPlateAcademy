using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoSystemStack : MonoBehaviour
{
    //Stack of strings
    //Perform Action Method which adds action to stack
    //Undo Last Action which removes alst action from stack
    //Get last action which gets the last action done without removing it
    //Undo all actions which removes all from stack
    //Save method that prevents undoing from a point
    // Start is called before the first frame update
    //Print all action that doesnt destroy stack

    public Stack<string> actionStack;
    void Start()
    {
        actionStack = new Stack<string>();
    }

  public void PerformActionMethod(string input)
    {
        actionStack.Push(input);
    }

    public void UndoLastAction()
    {
        if (actionStack.Count <= 0)
        {
            return;
        }
        if (actionStack.Peek() == "Save")
        {
            return;
        }
        actionStack.Pop();
    }

    public void GetLastAction()
    {
        Debug.Log(actionStack.Peek());
    }

    public void UndoAllActions()
    {
        int count = actionStack.Count;

        for (int i = 0; i < count; i++)
        {
            if (actionStack.Peek() != "Save")
            {
                actionStack.Pop();
            }
        }
    }

    public void Save()
    {
        actionStack.Push("Save");
    }

    public void PrintAll()
    {
        int count = actionStack.Count;
        Queue<string> tempQueue = new Queue<string>();

        for (int i = 0; i < count; i++)
        {
            string tempString = actionStack.Pop();
            Debug.Log(tempString);
            tempQueue.Enqueue(tempString);
        }

        for (int i = 0; i < count; i++)
        {
            actionStack.Push(tempQueue.Dequeue());
        }
    }

}
