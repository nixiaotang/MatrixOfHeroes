using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeacherStudent : MonoBehaviour
{

    public void OnTeacherButton() {
         SceneManager.LoadScene("TeacherSignIn");
    }

    public void OnStudentButton() {
        SceneManager.LoadScene("StudentSignIn");
    }
}
