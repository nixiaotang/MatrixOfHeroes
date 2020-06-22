using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StudentNewAccount : MonoBehaviour
{

    private string databaseURL = "https://matrix-of-heroes.firebaseio.com/";

    public InputField inputName;
    Student student = new Student();


    public void OnMakeAccount() {

        if(inputName.text != "") {
            
            student.username = inputName.text;
            RestClient.Put(databaseURL + "student/" + student.username +  ".json", student); //post to database
            
            GameManager.student = student;
            SceneManager.LoadScene("Character Menu");

        }
        
    }


    public void SignInScene() {
        SceneManager.LoadScene("StudentSignIn");
    }

}
