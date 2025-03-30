using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student : MonoBehaviour
{
    public string clubPosition;
    public List<Club> clubsList;
    public int grade;
    public int studentID;
    public string studentName;

    public Student(string tempName, int tempGrade)
    {
        studentName = tempName;
        grade = tempGrade;
        studentID = Random.Range(100000000, 1000000000);
    }
}
