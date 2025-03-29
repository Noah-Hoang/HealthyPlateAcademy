using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class School : MonoBehaviour
{
    public static School instance { get; private set; }
    public List<Club> clubsList;
    public List<Classroom> classroomList;
    public List<Student> studentsList;
    public List<SchoolStaff> staffList;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        return;
    }
    public Student CreateStudents(string name, int grade)
    {
        //TODO
        return null;
    }

    public Teacher CreateTeachers(string name, string subject, int age)
    {
        //TODO
        return null;
    }

    public Classroom CreateClassroom(int maxCapacity)
    {
        //Todo
        return null;
    }

    public Principal CreatePrincipal(string name, int age)
    {
        //Todo
        return null;
    }

    public Club CreateClub(string name, int classroomID, string descripotion, int facultyID)
    {
        //TODO
        return null;
    }

    public void RemoveTeachers(int facultyID)
    {

    }

    public void RemovePrincipal(int facultyID)
    {

    }

    public void RemoveClassrooms(int classroomID)
    {

    }

    public void RemoveClub(int clubID)
    {

    }

    public void RemoveStudents(int studentID)
    {

    }

    public Club GetClub(string name, int clubID)
    {
        return null;
    }

    public Teacher GetTeacher(string name, int facultyID)
    {
        return null;
    }

    public Student GetStudent(string name, int studentID)
    {
        return null;
    }

    public Principal GetPrincipal()
    {
        return null;
    }
}
