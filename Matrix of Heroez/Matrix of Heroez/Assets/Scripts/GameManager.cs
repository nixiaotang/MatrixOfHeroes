using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static string databaseURL = "https://matrix-of-heroes.firebaseio.com/";

    public static Student student = new Student();
    public static Teacher teacher = new Teacher();

    public static bool music = false;


    public static void UpdateStudent() {
        RestClient.Put(databaseURL + "student/" + student.username +  ".json", student); //post to database
        RestClient.Put(databaseURL + "teacher/" + student.teacherName + "/students/" + student.teacherInd + ".json", student);
    }
}


