using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LinkedList : MonoBehaviour
{
    private Node head; //First node in the linked list
    public int linkedListLength;

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
            linkedListLength++;
        }
        else
        {
            Node currentNode = head;
            while (currentNode.nextNode != null)
            {
                currentNode = currentNode.nextNode;
            }
            currentNode.nextNode = newNode;
            linkedListLength++;
        }
    }

    public void Start()
    {
        MakeBurger(2, true, 2, true);
        Node tempNode = new Node(0);
        AddAt(2);
        AddAt(2, tempNode);
        OrderBurger("Cheese");
        OrderBurger();
    }

    public void MakeBurger(int patties, bool hasCheese = false, int pickles = 2, bool useLettuce = false)
    {

    }
    public void OrderBurger(string extraTopping = "none")
    {
        Console.WriteLine("You ordered a burger with " + extraTopping);
    }
    public void AddAt(int index, Node newNode = null)
    {
        Node currentNode = head;
        int tempIndex = 0;

        if (newNode == null)
        {
            newNode = new Node(0);
        }

        if (index == 0)
        {
            newNode.nextNode = currentNode;
            head = newNode;
            return;
        }

        // 2 4 3 5
        while (tempIndex <= index && (linkedListLength > index))
        {
            if (tempIndex + 1 == index)
            {
                if (currentNode.nextNode.nextNode != null)
                {
                    newNode.nextNode = currentNode.nextNode.nextNode;
                    currentNode.nextNode = newNode;
                }
                else
                {
                    newNode.nextNode = currentNode.nextNode;
                    currentNode.nextNode = newNode;
                }
                return;
            }
            currentNode = currentNode.nextNode;
            tempIndex++;
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
            linkedListLength--;
        }

        //TODO: Check to see if the next next node exists
        // Check to see if index is bigger than linked list
        // -3 1 5 9 
        int tempIndex = 0;
        
        while (tempIndex <= index && (linkedListLength > index))
        {
            if (tempIndex + 1 == index)
            {
                if (currentNode.nextNode.nextNode == null)
                {
                    currentNode.nextNode = null;
                    linkedListLength--;
                    return;
                }
                else
                {
                    currentNode.nextNode = currentNode.nextNode.nextNode;
                    linkedListLength--;
                    return;
                }
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
