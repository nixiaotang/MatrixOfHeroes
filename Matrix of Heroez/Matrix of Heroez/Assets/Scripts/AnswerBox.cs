using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AnswerBox : MonoBehaviour
{
    public GameObject Placeholder;
    public TMP_InputField inputField;

    // Update is called once per frame
    void Update()
    {
        if (inputField.text == "")
        {
            Placeholder.SetActive(true);
        }
        else
        {
            Placeholder.SetActive(false);
        }
    }
}
