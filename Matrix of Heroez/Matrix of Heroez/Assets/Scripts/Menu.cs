using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{


    public TransitionScript ts;
    
    public void LevelPicker() {
        //ts.Transition("Character Menu");

        ts.Transition("TeacherStudent");
    }


    
    public void Quit() {
        Application.Quit();
    }
    
}
