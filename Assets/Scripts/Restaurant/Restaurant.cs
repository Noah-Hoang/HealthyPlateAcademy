using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restaurant : MonoBehaviour
{
    public static Restaurant instance { get; private set; }
    public CashRegister cashRegister;
    public Menu menu;
    public List<Waiters> waitersList;
    public List<Chefs> chefsList;
    public List<Busboys> busboysList;
    public List<Host> hostsList;
    public List<Tables> tablesList;
    public Queue<Customers> customersQueue;

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public void CreateStaff(int waiters, int chefs, int busboys, int hosts)
    {
        for (int i = 0; i < waiters; i++)
        {
            Waiters waiter = new Waiters();
            waitersList.Add(waiter);
            Debug.Log("Created" + "" + waiters + "" + "waiters");
        }

        for (int i = 0; i < chefs; i++)
        {
            Chefs chef = new Chefs();
            chefsList.Add(chef);
            Debug.Log("Created" + "" + chefs + "" + "chefs");
        }

        for (int i = 0; i < busboys; i++)
        {
            Busboys busboy = new Busboys();
            busboysList.Add(busboy);
            Debug.Log("Created" + "" + busboys + "" + "busboys");
        }

        for (int i = 0; i < hosts; i++)
        {
            Host host = new Host();
            hostsList.Add(host);
            Debug.Log("Created" + "" + hosts + "" + "hosts");
        }
    }

    public void CreateTables(int tablesPerWaiter)
    {
        for (int i = 0; i < waitersList.Count; i++)
        {
            for (int j = 0; j < tablesPerWaiter; j++)
            {
                Tables table = new Tables();
                tablesList.Add(table);
                waitersList[i].assignedTables.Add(table);
                Debug.Log("Created" + "" + tablesPerWaiter + "" + "Table Per Waiter");
            }
        }       
    }

    public void CreateCustomers(int customers)
    {
        for (int i = 0; i < customers; i++)
        {
            Customers customer = new Customers();
            customersQueue.Enqueue(customer);
            Debug.Log("Created" + "" + customers + "" + "custoemrs");
        }
    }

    public void PayEmployees()
    {
        
    }
}
