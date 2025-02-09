using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSupportQueue : MonoBehaviour
{
    //A queue of strings
    //Join queue that takes in customer name
    //Serve customer method that removes from queue and prints name
    //Get queue count method
    // Start is called before the first frame update

    public string inputString;
    public Queue<string> customerQueue;
    void Start()
    {
        customerQueue = new Queue<string>();
    }

    [ContextMenu("Join Queue")]
    public void JoinQueueCM()
    {
        JoinQueue(inputString);
    }

    public void JoinQueue(string input)
    {
        customerQueue.Enqueue(input);
    }

    [ContextMenu("Serve Customer")]
    public void ServeCustomer()
    {
        if (customerQueue.Count <= 0)
        {
            return;
        }
        Debug.Log(customerQueue.Dequeue() + " has been served");
    }

    [ContextMenu("Print Count")]
    public void PrintQueueCount()
    {
        Debug.Log(customerQueue.Count);
    }
}
