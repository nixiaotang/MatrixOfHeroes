using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Answering : MonoBehaviour
{


    ClosestEnemy closest;
    [SerializeField] TMP_InputField answerText;

    private int enemiesDestroyed;

    private GameObject enemy;


    void Start() {
        answerText.characterValidation = TMP_InputField.CharacterValidation.Integer;
        closest = GameObject.FindGameObjectWithTag("Player").GetComponent<ClosestEnemy>();
    }

    void Update() {

        if (Input.GetKeyDown("return")) {
            
            OnButtonEnter();
            
        }


    }
    

    public void OnButtonEnter() {

        if(answerText.text != "") {

            enemy = closest.FindClosest();

            if(enemy != null) {

                if(enemy.GetComponent<SeekPlayer>().answer.ToString() == answerText.text) {
                    enemiesDestroyed += 1;
                    Destroy(enemy);
                    if (enemiesDestroyed == 15)
                    {
                        SceneManager.LoadScene("WinScene");
                    }
                }

            }
            
            

        }


    }
}
