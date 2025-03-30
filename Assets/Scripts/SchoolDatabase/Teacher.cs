using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher : SchoolStaff, IClubHandler
{
    public string subject;
    public List<Club> clubsList;
    public Classroom classroom;

    public Teacher(string tempName, string tempSubject, int tempAge)
    {
        staffName = tempName;
        subject = tempSubject;
        age = tempAge;
        facultyID = Random.Range(100000000, 1000000000);
    }
    public void RequestFunding(float money, int clubID)
    {
        //TODO
    }

    public void AddFunding(float monye, int clubID)
    {
        //TODO
    }

    public Club RequestCreateClub(string name, int classroomID, string description, int facultyID)
    {
        Club club = School.instance.CreateClub(name, classroomID, description, facultyID);
        if (club != null)
        {
            return club;
        }
        return null;
    }

    public void RequestRemoveClub(int clubID)
    {
        School.instance.RemoveClub(clubID);
    }

    public void AddStduentToClub(int studentID, int clubID)
    {
        //TODO: add logic for student/club name or student/club id
        Student student = School.instance.GetStudent(studentID, "");
        Club club = School.instance.GetClub(clubID, "");
        club.membersList.Add(student);
    }

    public void RemoveStudentFromClub(int studentID, int clubID)
    {
        Student student = School.instance.GetStudent(studentID, "");
        Club club = School.instance.GetClub(clubID, "");
        club.membersList.Remove(student);
    }
}
