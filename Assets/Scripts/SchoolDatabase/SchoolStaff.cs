using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WebSocketSharp;

public class SchoolStaff : MonoBehaviour
{
    public string staffName;
    public float salary;
    public int facultyID;
    public int age;

    public List<SchoolStaff> ShowAllFaculty(string searchedName = "")
    {
        List<SchoolStaff> schoolStaff = School.instance.teachersList.Cast<SchoolStaff>().ToList();
        schoolStaff.Add(School.instance.currentPrincipal);
        List<SchoolStaff> filteredStaff = new List<SchoolStaff>();
        if (searchedName.IsNullOrEmpty())
        {
            return schoolStaff;
        }

        for (int i = 0; i < schoolStaff.Count; i++)
        {
            if (schoolStaff[i].staffName.Contains(searchedName))
            {
                filteredStaff.Add(schoolStaff[i]);
            }
        }

        if (filteredStaff.Count == 0)
        {
            return null;
        }

        return filteredStaff;
    }

    public List<SchoolStaff> ShowAllFaculty(int tempFacultyID = -1)
    {
        List<SchoolStaff> schoolStaff = School.instance.teachersList.Cast<SchoolStaff>().ToList();
        schoolStaff.Add(School.instance.currentPrincipal);
        List<SchoolStaff> filteredStaff = new List<SchoolStaff>();
        if (tempFacultyID == -1)
        {
            return null;
        }

        for (int i = 0; i < schoolStaff.Count; i++)
        {
            if (schoolStaff[i].facultyID == tempFacultyID)
            {
                filteredStaff.Add(schoolStaff[i]);
            }
        }

        if (filteredStaff.Count == 0)
        {
            return null;
        }

        return filteredStaff;
    }

    public List<Club> ShowAllClubs(string searchedName = "")
    {
        List<Club> clubs = School.instance.clubsList;
        List<Club> filteredClubs = new List<Club>();
        if (searchedName.IsNullOrEmpty())
        {
            return clubs;
        }

        for (int i = 0; i < clubs.Count; i++)
        {
            if (clubs[i].clubName.Contains(searchedName))
            {
                filteredClubs.Add(clubs[i]);
            }
        }

        if (filteredClubs.Count == 0)
        {
            return null;
        }

        return filteredClubs;
    }

    public List<Club> ShowAllClubs(int tempClubID = -1)
    {
        List<Club> clubs = School.instance.clubsList;
        List<Club> filteredClubs = new List<Club>();
        if (tempClubID == -1)
        {
            return null;
        }

        for (int i = 0; i < clubs.Count; i++)
        {
            if (clubs[i].clubID == tempClubID)
            {
                filteredClubs.Add(clubs[i]);
            }
        }

        if (filteredClubs.Count == 0)
        {
            return null;
        }

        return filteredClubs;
    }

    public List<Student> ShowAllStudents(string searchedName = "")
    {
        List<Student> students = School.instance.studentsList;
        List<Student> filteredStudents = new List<Student>();
        if (searchedName.IsNullOrEmpty())
        {
            return students;
        }

        for (int i = 0; i < students.Count; i++)
        {
            if (students[i].studentName.Contains(searchedName))
            {
                filteredStudents.Add(students[i]);
            }
        }

        if (filteredStudents.Count == 0)
        {
            return null;
        }

        return filteredStudents;
    }

    public List<Student> ShowAllStudents(int tempStudentID = -1)
    {
        List<Student> students = School.instance.studentsList;
        List<Student> filteredStudents = new List<Student>();
        if (tempStudentID == -1)
        {
            return null;
        }

        for (int i = 0; i < students.Count; i++)
        {
            if (students[i].studentID == tempStudentID)
            {
                filteredStudents.Add(students[i]);
            }
        }

        if (filteredStudents.Count == 0)
        {
            return null;
        }

        return filteredStudents;
    }

    public List<Student> ShowStudentsInClub(int tempClubID = -1)
    {
        List<Club> clubs = School.instance.clubsList;
        List<Student> studentsInClub = new List<Student>();
        if (tempClubID == -1)
        {
            return null;
        }

        for (int i = 0; i < clubs.Count; i++)
        {
            if (clubs[i].clubID == tempClubID)
            {
                studentsInClub = clubs[i].membersList;
            }
        }

        return studentsInClub;
    }

    public List<Classroom> ShowAllClassroom()
    {
        return School.instance.classroomList;
    }
}
