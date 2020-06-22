using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class LevelPicker : MonoBehaviour
{
    public TransitionScript ts;
    public EventSystem evt;
    public void T1Q1() {
        ts.Transition("T1Q1");
    }

    public void T1Q2() {
        ts.Transition("T1Q2");
    }

    public void T1C1() {
        ts.Transition("T1C1");
    }

    public void T1Q3() {
        ts.Transition("T1Q3");
    }

    public void T1Q4() {
        ts.Transition("T1Q4");
    }

    public void T1C2() {
        ts.Transition("T1C2");
    }

    public void Boss() {
        ts.Transition("Boss");
    }


    
    [SerializeField] private GameObject[] levelButtonImages;


    private string databaseURL = "https://matrix-of-heroes.firebaseio.com/";

    [SerializeField] private GameObject connectTeacher;
    [SerializeField] private TextMeshProUGUI teacherText;
    public InputField teacherName;
    

    Teacher teacher = new Teacher();


    void Start() {


        if(GameManager.student.teacherName != "") {
            connectTeacher.SetActive(false);
            teacherText.text = "Teacher : " + GameManager.student.teacherName;
        } else {
            teacherText.text = "Teacher : not connected";
            connectTeacher.SetActive(true);
        }


        for(int i = 0; i <= GameManager.student.progress; i++) {

            levelButtonImages[i].SetActive(true);

        }

        GameManager.UpdateStudent();

    }


    public void OnTeacherEnter() {
        if(teacherName.text != "") {
            
            RestClient.Get<Teacher>(databaseURL + "teacher/" + teacherName.text +  ".json").Then(response => {
                teacher = response;
                AddStudent();
            });

        }
        evt.SetSelectedGameObject(null);
        
    }

    private void AddStudent() {

        GameManager.student.teacherName = teacherName.text;
        GameManager.student.teacherInd = teacher.students.Count;

        teacher.students.Add(GameManager.student);

        RestClient.Put(databaseURL + "teacher/" + teacher.teacherName +  ".json", teacher); //post to database

        GameManager.UpdateStudent();

        //connectTeacher.SetActive(false);
        teacherText.text = "Teacher : " + GameManager.student.teacherName;
    }




}
