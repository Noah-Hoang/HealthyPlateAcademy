using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Principal : SchoolStaff, IClubHandler, ISchoolRegistry
{
    public List<Club> allClubsList;
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
        Student student = School.instance.GetStudent("", studentID);
        Club club = School.instance.GetClub("" , clubID);
        club.membersList.Add(student);
    }

    public void RemoveStudentFromClub(int studnetID, int clubID)
    {

    }

    public Student RequestCreateStudents(string name, int grade)
    {
        throw new System.NotImplementedException();
    }

    public void RequestRemoveStudents(int studentID)
    {
        throw new System.NotImplementedException();
    }

    public Teacher RequestCreateTeachers(string name, string subject, int age)
    {
        throw new System.NotImplementedException();
    }

    public void RequestRemoveTeachers(int facultyID)
    {
        throw new System.NotImplementedException();
    }

    public Principal RequestCreatePrincipal(string name, int age)
    {
        throw new System.NotImplementedException();
    }

    public void RequestRemovePrincipal(int facultyID)
    {
        throw new System.NotImplementedException();
    }

    public Classroom RequestCreateClassroom(int maxCapacity)
    {
        throw new System.NotImplementedException();
    }

    public void RequestRemoveClassrooms(int classRoomID)
    {
        throw new System.NotImplementedException();
    }
}
