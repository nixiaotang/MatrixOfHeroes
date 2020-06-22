using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Student {

    public string username;
    public int progress = 0;
    public bool boy;

    public string teacherName = "";
    public int teacherInd = -1;

}


[System.Serializable]
public class Teacher {

    public string teacherName;
    public List<Student> students = new List<Student>();

}


