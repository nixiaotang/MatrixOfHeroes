using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScript : MonoBehaviour
{
    public Animator anime;
    
    // Start is called before the first frame update
    public void Transition(string level)
    {
        LoadNextLevel(level);
    }

    public void LoadNextLevel(string level)
    {
        StartCoroutine(LoadLevel(level));
    }

    IEnumerator LoadLevel(string level)
    {
        anime.SetTrigger("Start");
        
        yield return new WaitForSeconds(1f);
        
        SceneManager.LoadScene(level);
    }
}
