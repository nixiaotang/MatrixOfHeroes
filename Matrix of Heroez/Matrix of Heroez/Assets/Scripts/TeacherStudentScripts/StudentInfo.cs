using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudentInfo : MonoBehaviour
{


    private Text studentNameText;
    private Text progressText;

    
    public void InfoUpdate(string name, int progress) {

        foreach (Transform t in transform) {
            if(t.name == "StudentName") studentNameText = t.gameObject.GetComponent<Text>();
            else if (t.name == "Progress") progressText = t.gameObject.GetComponent<Text>();
        }

        studentNameText.text = name;
        progressText.text = "Progress : " + progress.ToString();
        
    }


}
