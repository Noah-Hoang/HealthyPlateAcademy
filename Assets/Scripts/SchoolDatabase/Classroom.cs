using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classroom : MonoBehaviour
{
    public Club currentClub;
    public int maxCapacity;
    public int classroomID;
    public Teacher teacher;

    public Classroom(int tempMaxCapacity)
    {
        maxCapacity = tempMaxCapacity;
        classroomID = Random.Range(100000000, 1000000000);
    }
}
