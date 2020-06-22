using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class T1Q1 {

    public int a;
    public int b;
    public int ans;

    public T1Q1() {
        this.a = Random.Range(0, 10);
        this.b = Random.Range(0, 10);
        this.ans = a + b;
    }

}


[System.Serializable]
public class T1Q2 {

    public int a;
    public int b;
    public int ans;

    public T1Q2() {
        this.a = Random.Range(0, 10);
        this.b = Random.Range(0, this.a);
        this.ans = a - b;
    }

}


[System.Serializable]
public class T1Q3 {

    public int a;
    public int b;
    public int ans;

    public T1Q3() {
        this.a = Random.Range(0, 10);
        this.b = Random.Range(0, 10);
        this.ans = a * b;
    }

}


[System.Serializable]
public class T1Q4 {

    public int a;
    public int b;
    public int ans;

    public T1Q4() {
        this.b = Random.Range(1, 10);
        this.ans = Random.Range(0, 10);
        this.a = ans * b;
    }

}

