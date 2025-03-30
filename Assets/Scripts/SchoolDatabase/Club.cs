using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour
{
    public float funding;
    public List<Student> membersList;
    public int currentClassroomID;
    public int clubAdvisorID;
    public string description;
    public string clubName;
    public int clubID;


    public Club (string tempName, int tempClassroomID, string tempDescripotion, int tempFacultyID)
    {
        clubName = tempName;
        description = tempDescripotion;
        clubAdvisorID = tempFacultyID;
        currentClassroomID = tempClassroomID;
        
    }
    public void ReportStatus()
    {

    }
}
