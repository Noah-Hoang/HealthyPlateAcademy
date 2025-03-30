using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISchoolRegistry 
{
    public Student RequestCreateStudents(string name, int grade);
    public void RequestRemoveStudents(int studentID);

    public Teacher RequestCreateTeachers(string name, string subject, int age);
    public void RequestRemoveTeachers(int facultyID);

    public Principal RequestCreatePrincipal(string name, int age);
    public void RequestRemovePrincipal();

    public Classroom RequestCreateClassroom(int maxCapacity);
    public void RequestRemoveClassrooms(int classRoomID);

}
