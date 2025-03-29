using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IClubHandler 
{
    public void RequestFunding(float money, int clubID);
    public void AddFunding(float money, int clubID);

    public Club RequestCreateClub(string name, int classroomID, string description, int facultyID);
    public void RequestRemoveClub(int clubID);

    public void AddStduentToClub(int studentID, int clubID);
    public void RemoveStudentFromClub(int studentID, int clubID);


}
