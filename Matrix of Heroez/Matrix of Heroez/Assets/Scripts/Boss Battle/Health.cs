using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public GameObject HOne;
    public GameObject HTwo;
    public GameObject HThree;
    public GameObject HFour;
    public GameObject HFive;
    public GameObject HSix;

    public int hitCounter;



    // Start is called before the first frame update
    void Start()
    {
        hitCounter = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (hitCounter == 1)
        {
            HOne.SetActive(false);

        }
        if (hitCounter == 2)
        {
            HTwo.SetActive(false);

        }
        if (hitCounter == 3)
        {
            HThree.SetActive(false);

        }
        if (hitCounter == 4)
        {
            HFour.SetActive(false);

        }
        if (hitCounter == 5)
        {
            HFive.SetActive(false);

        }
        if (hitCounter == 6)
        {
            SceneManager.LoadScene("GameOver");
        }
    }



}
