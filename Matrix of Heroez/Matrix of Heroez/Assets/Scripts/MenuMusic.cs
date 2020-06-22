using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{

    void Start() {
        if(!GameManager.music) GameManager.music = true;
        else Destroy(this.gameObject);
    }

    private void Update()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
