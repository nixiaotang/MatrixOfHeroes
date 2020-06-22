using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Questions : MonoBehaviour
{
    public TransitionScript ts;
    
    private int questions = 1;
    private int curAns;
    private bool answered = false;


    [SerializeField] int questionSet = 0;

    [SerializeField] private EventSystem evt;
    
    [SerializeField] private TextMeshProUGUI questionsTxt;
    [SerializeField] private TMP_InputField inputField;

    [SerializeField] private GameObject girlPanel;

    [SerializeField] private GameObject feedbackTxt;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject continueButton;





    // Start is called before the first frame update
    void Start() {

        inputField.characterValidation = TMP_InputField.CharacterValidation.Integer;;

        Question();
        feedbackTxt.SetActive(false);
        nextButton.SetActive(false);
        continueButton.SetActive(false);


        if(GameManager.student.boy) girlPanel.SetActive(false);
        
    }



    void Update() {

        if (Input.GetKeyDown("return")) {
            
            if(!answered) Enter();
            else if (questions <= 10) Question();
            else LevelPicker();
            
        }


    }


    public void Exit()
    {
        ts.Transition("LevelPicker");
    }

    public void Question() {
        switch(questionSet) {
            case 0 : 
                T1Q1();
            break;
            case 1 :
                T1Q2();
            break;
        }

    }
    
    public void Enter() {
        if(!answered) {

            string answer = inputField.text;

            if (answer == "")
            {
                feedbackTxt.GetComponent<TextMeshProUGUI>().text = "NO ANSWER SUBMITTED!";
                evt.SetSelectedGameObject(null);
            }

            
            else {
                
                answered = true;
                if(answer == curAns.ToString()) feedbackTxt.GetComponent<TextMeshProUGUI>().text = "CORRECT!";
                else feedbackTxt.GetComponent<TextMeshProUGUI>().text = "INCORRECT! The correct answer is " + curAns.ToString();

                questions ++;

                if(questions > 10) continueButton.SetActive(true);
                else nextButton.SetActive(true);
            }

            feedbackTxt.SetActive(true);


        }
        
    }




    public void T1Q1() { //addition under 10

        answered = false;

        int a = Random.Range(0, 10);
        int b = Random.Range(0, 10);

        questionsTxt.text = questions.ToString() + ")   " + a.ToString() + " + " + b.ToString() + " =";
        inputField.text = "";

        curAns = a + b;

        nextButton.SetActive(false);
        feedbackTxt.SetActive(false);

    }



    public void T1Q2() { //subtraction under 10

        answered = false;

        int a = Random.Range(0, 10);
        int b = Random.Range(0, a);

        questionsTxt.text = questions.ToString() + ")   " + a.ToString() + " - " + b.ToString() + " =";
        inputField.text = "";

        curAns = a - b;

        nextButton.SetActive(false);
        feedbackTxt.SetActive(false);

    }


    public void LevelPicker() {

        GameManager.student.progress = Mathf.Max(questionSet+1, GameManager.student.progress);
        GameManager.UpdateStudent();

        SceneManager.LoadScene("LevelPicker");
    }


}
