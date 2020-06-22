using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TeacherSignIn : MonoBehaviour
{

    private string databaseURL = "https://matrix-of-heroes.firebaseio.com/";

    public InputField inputName;
    Teacher teacher = new Teacher();

    [SerializeField] private GameObject invalidText;


    public void OnSignIn() {

        if(inputName.text != "") {
            
            RestClient.Get<Teacher>(databaseURL + "teacher/" + inputName.text +  ".json").Then(response => {
                teacher = response;
                GameManager.teacher = teacher;
                
                SceneManager.LoadScene("TeacherMonitor");
            }).Catch(err => {
                invalidText.SetActive(true);
            });
            

        } else invalidText.SetActive(true);
            
        
    }

    public void NewTeacherAccountScene() {
        SceneManager.LoadScene("TeacherNewAccount");
    }
}
