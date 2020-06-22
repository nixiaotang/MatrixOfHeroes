using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StudentSignIn : MonoBehaviour
{


    private string databaseURL = "https://matrix-of-heroes.firebaseio.com/";

    public InputField inputName;
    Student student = new Student();

    [SerializeField] private GameObject invalidText;


    public void OnSignIn() {

        if(inputName.text != "") {
            
            RestClient.Get<Student>(databaseURL + "student/" + inputName.text +  ".json").Then(response => {
                student = response;
                GameManager.student = student;

                SceneManager.LoadScene("LevelPicker");
            
            }).Catch(err => {
                invalidText.SetActive(true);
            });
            

        } else invalidText.SetActive(true);
        
    }



    public void NewAccountScene() {
        SceneManager.LoadScene("StudentNewAccount");
    }
}
