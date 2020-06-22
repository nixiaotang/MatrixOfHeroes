using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TeacherNewAccount : MonoBehaviour
{

    private string databaseURL = "https://matrix-of-heroes.firebaseio.com/";

    public InputField inputName;
    Teacher teacher = new Teacher();


    public void OnMakeAccount() {

        if(inputName.text != "") {
            
            teacher.teacherName = inputName.text;

            RestClient.Put(databaseURL + "teacher/" + teacher.teacherName +  ".json", teacher); //post to database
            
            TeacherSignInScene();

        }
        
    }


    public void TeacherSignInScene() {
        SceneManager.LoadScene("TeacherSignIn");
    }
}
