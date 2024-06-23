using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public void Start()
    {
        Looks();
    }

    public void OnEnable()
    {
        TurnOn();
    }

    public void OnDisable()
    {
        TurnOff();
    }

    public virtual void TurnOff()
    {
        // Basic way to move any vehicle
        Debug.Log("Turning Car Off");
    }
    public virtual void TurnOn()
    {
        // Basic way to move any vehicle
        Debug.Log("Turning Car On");
    }
    public virtual void Move()
    {
        // Basic way to move any vehicl
    }
    public virtual void Looks() 
    {
        // Basic way to move any vehicle
        Debug.Log("Infinity G35");
    }
}