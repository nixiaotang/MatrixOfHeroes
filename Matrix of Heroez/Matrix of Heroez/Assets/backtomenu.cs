using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backtomenu : MonoBehaviour
{
    // Update is called once per frame
    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
}
