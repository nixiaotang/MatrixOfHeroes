using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeButton : MonoBehaviour
{
    
    [SerializeField] private Challenge challenge;
    [SerializeField] private bool a;

    int answer;

    private Text t;



    void Awake() {

        t = gameObject.transform.Find("Text").GetComponent<Text>();

        switch(challenge.questionSet) {
            case 2 :

                if(a) {
                    T1Q1 q = new T1Q1();
                    t.text = q.a.ToString() + " + " + q.b.ToString();
                    answer = q.ans;
                    challenge.answers.Add(answer);

                } else {

                    T1Q2 q2 = new T1Q2();
                    t.text = q2.a.ToString() + " - " + q2.b.ToString();
                    answer = q2.ans;
                    challenge.answers.Add(answer);
                }
                
            break;
            case 5 :

                if(a) {
                    T1Q3 q3 = new T1Q3();
                    t.text = q3.a.ToString() + " x " + q3.b.ToString();
                    answer = q3.ans;
                    challenge.answers.Add(answer);

                } else {

                    T1Q4 q4 = new T1Q4();
                    t.text = q4.a.ToString() + " ÷ " + q4.b.ToString();
                    answer = q4.ans;
                    challenge.answers.Add(answer);
                }


            break;
        }
        
    }

    
    public void OnClick() {

       if(challenge.curNum == answer) {

           challenge.answers.Remove(answer);
           challenge.Next();
           Destroy(this.gameObject);

       }
    }


}
