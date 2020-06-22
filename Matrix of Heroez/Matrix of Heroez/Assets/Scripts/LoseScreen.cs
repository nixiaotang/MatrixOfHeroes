using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseScreen : MonoBehaviour
{
    public TransitionScript ts;
  
    public void menu()
    {
        ts.Transition("Menu");
    }
  
    public void playAgain()
    { 
        ts.Transition("LevelPicker");
    }
}
