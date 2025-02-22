using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LinkedList 
{
    private Node head; //First node in the linked list

    public void Add(int value)
    {
        ////secondNode is just a node and 10 is the int inside the node
        ////Since constructor sets nextNode = null, you don't have to fill it in for the parameters
        ////In order for the firstNode to get to the secondNode, you need to fill in the parameter for the nextNode so that the list can track that as the next node
        //Node secondNode = new Node(10);
        //Node firstNode = new Node(5, secondNode);


        Node newNode = new Node(value);

        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node currentNode = head;
            while (currentNode.nextNode != null)
            {
                currentNode = currentNode.nextNode;
            }
            currentNode.nextNode = newNode;
        }
    }
    
    public int GetValueAt(int index)
    {
        Node currentNode = head;
        int tempIndex = 0;
        while (tempIndex < index)
        {
            currentNode = currentNode.nextNode;
            tempIndex++;
        }
        return currentNode.value;
    }

    public void RemoveAt(int index)
    {
        Node currentNode = head;

        if (index == 0)
        {
            head = currentNode.nextNode;
        }

        //TODO: Check for nulls and index being bigger than linked list
        // -3 1 5
        int tempIndex = 0;
        while (tempIndex <= index)
        {
            if (tempIndex + 1 == index)
            {
                currentNode.nextNode = currentNode.nextNode.nextNode;
                return;
            }
            currentNode = currentNode.nextNode;
            tempIndex++;
        }
    }

    public void RemoveValue(int value)
    {

    }

    public void PrintLinkList()
    {
        Node currentNode = head;
        while (currentNode != null)
        {
            Debug.Log(currentNode.value);
            currentNode = currentNode.nextNode;
        }
    }
}
