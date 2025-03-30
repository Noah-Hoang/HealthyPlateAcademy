using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Principal : SchoolStaff, IClubHandler, ISchoolRegistry
{
    public List<Club> allClubsList;

    public Principal(string tempName, int tempAge)
    {
        staffName = tempName;
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

    public Student RequestCreateStudents(string name, int grade)
    {
        Student student = School.instance.CreateStudents(name, grade);
        return student;
    }

    public void RequestRemoveStudents(int studentID)
    {
        School.instance.RemoveStudents(studentID);
    }

    public Teacher RequestCreateTeachers(string name, string subject, int age)
    {
        Teacher teacher = School.instance.CreateTeachers(name, subject, age);
        return teacher;
    }

    public void RequestRemoveTeachers(int facultyID)
    {
        School.instance.RemoveTeachers(facultyID);
        throw new System.NotImplementedException();
    }

    public Principal RequestCreatePrincipal(string name, int age)
    {
        Principal principal = School.instance.CreatePrincipal(name, age);
        return principal;
    }

    public void RequestRemovePrincipal()
    {
        School.instance.RemovePrincipal();
    }

    public Classroom RequestCreateClassroom(int maxCapacity)
    {
        Classroom classroom = School.instance.CreateClassroom(maxCapacity);
        return classroom;
    }

    public void RequestRemoveClassrooms(int classRoomID)
    {
        School.instance.RemoveClassrooms(classRoomID);
    }
}
