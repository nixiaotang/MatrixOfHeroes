using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeachNameInput : MonoBehaviour
{
    public GameObject Placeholder;
    public InputField inputField;

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
