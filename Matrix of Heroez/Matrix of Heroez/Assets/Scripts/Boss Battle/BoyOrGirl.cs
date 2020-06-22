using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyOrGirl : MonoBehaviour
{

    public GameObject boy;
    public GameObject girl;

    // Start is called before the first frame update
    void Awake()
    {
        if (GameManager.student.boy)
        {
            Destroy(girl);
        }
        else
        {
            Destroy(boy);
        }
    }


}
