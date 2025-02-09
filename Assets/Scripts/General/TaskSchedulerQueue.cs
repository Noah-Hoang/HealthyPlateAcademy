using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSchedulerQueue : MonoBehaviour
{
    //Have a string that you can enter
    //Method called AddTask that takes in a string
    //Method called ProcessNextTask that takes from queue and prints
    //Method called IsTaskSchedulerEmptty, returns true if nothing in queue
    // Start is called before the first frame update

    public string taskInput;
    public Queue<string> taskQueue;
    void Start()
    {
        taskQueue = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("Add Task")]
    public void AddTaskContextMenu()
    {
        AddTask(taskInput);
    }

    public void AddTask(string input)
    {
        taskQueue.Enqueue(input);
    }

    [ContextMenu("Process Task")]
    public void ProcessNextTask()
    {
        if (taskQueue.Count <= 0)
        {
            return;
        }

        Debug.Log(taskQueue.Dequeue());
    }

    [ContextMenu("Check if Empty")]
    public bool IsTaskSchedulerEmpty()
    {
        if (taskQueue.Count == 0)
        {
            return true;
        }
        return false;
    }
}
