using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class School : MonoBehaviour
{
    public static School instance { get; private set; }
    public List<Club> clubsList;
    public List<Classroom> classroomList;
    public List<Student> studentsList;
    public List<Teacher> teachersList;
    public Principal currentPrincipal;

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
        Student student = new Student(name, grade);
        studentsList.Add(student);
        return student;
    }

    public Teacher CreateTeachers(string name, string subject, int age)
    {
        Teacher teacher = new Teacher(name, subject, age);
        teachersList.Add(teacher);
        return teacher;
    }

    public Classroom CreateClassroom(int maxCapacity)
    {
        Classroom classroom = new Classroom(maxCapacity);
        classroomList.Add(classroom);
        return classroom;
    }

    public Principal CreatePrincipal(string name, int age)
    {
        Principal principal = new Principal(name, age);
        currentPrincipal = principal;
        return principal;
    }

    public Club CreateClub(string name, int classroomID, string description, int facultyID)
    {
        Club club = new Club(name, classroomID, description, facultyID);
        clubsList.Add(club);
        return club;
    }

    public bool RemoveTeachers(int facultyID)
    {
        Teacher teacher = GetTeacher(facultyID);

        if (teacher == null)
        {
            return false;
        }

        teachersList.Remove(teacher);
        return true;
    }

    public bool RemovePrincipal()
    {
        if (currentPrincipal != null)
        {
            currentPrincipal = null;
            return true;
        }
        return false;
    }

    public bool RemoveClassrooms(int classroomID)
    {
        Classroom classroom = GetClassroom(classroomID);

        if (classroom == null)
        {
            return false;
        }

        classroomList.Remove(classroom);
        return true;
    }

    public bool RemoveClub(int clubID)
    {
        Club club = GetClub(clubID);

        if (club == null)
        {
            return false;
        }

        clubsList.Remove(club);
        return true;
    }

    public bool RemoveStudents(int studentID)
    {
        Student student = GetStudent(studentID);

        if (student == null)
        {
            return false;
        }

        studentsList.Remove(student);
        return true;
    }

    public Club GetClub(int clubID = 0, string name = "")
    {
        if (clubID <= 0)
        {
            for (int i = 0; i < clubsList.Count; i++)
            {
                if (clubsList[i].clubID == clubID)
                {
                    return clubsList[i];
                }
            }
        }

        if (name != null)
        {
            for (int i = 0; i < clubsList.Count; i++)
            {
                if (clubsList[i].clubName == name)
                {
                    return clubsList[i];
                }
            }
        }

        return null;
    }

    public Teacher GetTeacher(int facultyID = 0, string name = "")
    {
        if (facultyID <= 0)
        {
            for (int i = 0; i < teachersList.Count; i++)
            {
                if (teachersList[i].facultyID == facultyID)
                {
                    return teachersList[i];
                }
            }
        }

        if (name != null)
        {
            for (int i = 0; i < teachersList.Count; i++)
            {
                if (teachersList[i].staffName == name)
                {
                    return teachersList[i];
                }
            }
        }

        return null;
    }

    public Student GetStudent(int studentID = 0, string name = "")
    {

        if (studentID <= 0)
        {
            for (int i = 0; i < studentsList.Count; i++)
            {
                if (studentsList[i].studentID == studentID)
                {
                    return studentsList[i];
                }
            }
        }

        if (name != null)
        {
            for (int i = 0; i < studentsList.Count; i++)
            {
                if (studentsList[i].studentName == name)
                {
                    return studentsList[i];
                }
            }
        }

        return null;
    }

    public Classroom GetClassroom(int classroomID)
    {
        if (classroomID <= 0)
        {
            for (int i = 0; i < classroomList.Count; i++)
            {
                if (classroomList[i].classroomID == classroomID)
                {
                    return classroomList[i];
                }
            }
        }

        return null;
    }
    public Principal GetPrincipal()
    {
        return currentPrincipal;
    }
}
