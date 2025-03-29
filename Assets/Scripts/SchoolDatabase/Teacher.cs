using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher : SchoolStaff, IClubHandler
{
    public string subject;
    public List<Club> clubsList;
    public void RequestFunding(float money, int clubID)
    {

    }

    public void AddFunding(float monye, int clubID)
    {

    }


    public Club RequestCreateClub(string name, int classroomID, string description, int facultyID)
    {
        //TODO
        return null;
    }

    public void RequestRemoveClub(int clubID)
    {

    }

    public void AddStduentToClub(int studentID, int clubID)
    {

    }

    public void RemoveStudentFromClub(int studnetID, int clubID)
    {

    }
}
