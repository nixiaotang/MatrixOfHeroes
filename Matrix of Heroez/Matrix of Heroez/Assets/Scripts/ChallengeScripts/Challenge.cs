using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Challenge : MonoBehaviour
{
    public TransitionScript ts;
    

    public int questionSet = 0;

    private string[] questions = new string[6];
    public List<int> answers = new List<int>();

    public int curNum;

    [SerializeField] private GameObject girlPanel;


    [SerializeField] private GameObject curNumObj;
    [SerializeField] private Text curNumText;
    [SerializeField] private GameObject continueButton;


    void Start() {

        if(GameManager.student.boy) girlPanel.SetActive(false);

        Next();

        
    }


    public void Next() {

        if(answers.Count <= 0) {

            curNumObj.SetActive(false);
            continueButton.SetActive(true);

        } else {

            curNum = answers[Random.Range(0, answers.Count)];
            curNumText.text = curNum.ToString();

        }

    }



    public void Exit()
    {
        ts.Transition("LevelPicker");
    }


    public void LevelPicker() {

        GameManager.student.progress = Mathf.Max(questionSet+1, GameManager.student.progress);
        GameManager.UpdateStudent();

        SceneManager.LoadScene("LevelPicker");
    }


}
