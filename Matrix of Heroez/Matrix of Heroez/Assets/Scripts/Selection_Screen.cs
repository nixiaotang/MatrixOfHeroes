using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selection_Screen : MonoBehaviour
{
    public Animator boyButton;
    public Animator girlButton;
    public int selected = 0;
    public TransitionScript ts;


    Student student = new Student();
    private string databaseURL = "https://matrix-of-heroes.firebaseio.com/";
    

    
    public void playGame()
    {
        if (selected != 0)
        {

            student = GameManager.student;

            if(selected == 1) student.boy = true;
            else student.boy = false;

            RestClient.Put(databaseURL + "student/" + student.username +  ".json", student); //post to database

            ts.Transition("LevelPicker");
        }
    }
    
    
    // Update is called once per frame
    void Update()
    {
        if (boyButton.GetCurrentAnimatorStateInfo(0).IsName("Selected"))
        {
            selected = 1;
        }
        
        
        else if (girlButton.GetCurrentAnimatorStateInfo(0).IsName("Selected"))
        {
            selected = 2;
        }

        else
        {
            selected = 0;
        }
        
    }
}
