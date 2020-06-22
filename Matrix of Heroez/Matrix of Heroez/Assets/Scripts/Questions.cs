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

    private int correctQuestions = 0;


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
            else Question();
            
        }


    }


    public void Exit()
    {
        ts.Transition("LevelPicker");
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
                if(answer == curAns.ToString()) {
                    feedbackTxt.GetComponent<TextMeshProUGUI>().text = "CORRECT!";
                    correctQuestions ++;
                    
                } else feedbackTxt.GetComponent<TextMeshProUGUI>().text = "INCORRECT! The correct answer is " + curAns.ToString();

                questions ++;

                nextButton.SetActive(true);
            }

            feedbackTxt.SetActive(true);


        }
        
    }


    public void Question() {

        
        if(questions > 10) {
            nextButton.SetActive(false);
            continueButton.SetActive(true);
            feedbackTxt.SetActive(false);

            if(correctQuestions >= 5) questionsTxt.text = "PRACTICE COMPLETE! " + correctQuestions.ToString() + "/10 correct!";
            else questionsTxt.text = "TRY AGAIN! " + correctQuestions.ToString() + "/10 correct!";

            return;
        }




        answered = false;

        switch(questionSet) {
            case 0 : 

                T1Q1 q = new T1Q1();
                questionsTxt.text = questions.ToString() + ")   " + q.a.ToString() + " + " + q.b.ToString() + " =";
                curAns = q.ans;

            break;
            case 1 :
                
                T1Q2 q2 = new T1Q2();
                questionsTxt.text = questions.ToString() + ")   " + q2.a.ToString() + " - " + q2.b.ToString() + " =";
                curAns = q2.ans;

            break;
            case 3 :
                
                T1Q3 q3 = new T1Q3();
                questionsTxt.text = questions.ToString() + ")   " + q3.a.ToString() + " x " + q3.b.ToString() + " =";
                curAns = q3.ans;

            break;
            case 4 :
                
                T1Q4 q4 = new T1Q4();
                questionsTxt.text = questions.ToString() + ")   " + q4.a.ToString() + " ÷ " + q4.b.ToString() + " =";
                curAns = q4.ans;

            break;
        }

        inputField.text = "";


        nextButton.SetActive(false);
        feedbackTxt.SetActive(false);

    }



    public void LevelPicker() {

        if(correctQuestions >= 5) {
            GameManager.student.progress = Mathf.Max(questionSet+1, GameManager.student.progress);
            GameManager.UpdateStudent();
        }

        SceneManager.LoadScene("LevelPicker");
    }


}
