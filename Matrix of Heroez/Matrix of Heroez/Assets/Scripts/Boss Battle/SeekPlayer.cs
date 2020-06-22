using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeekPlayer : MonoBehaviour
{

    [SerializeField] public bool Hunting;
    public int EnemySpeed;
    public GameObject playa;

    public bool isDestroy;

    public Health HealthScript;
    public GameObject HealthBa;
    public bool hit;


    private float xChange;
    private float yChange;
    [SerializeField]  private bool TargetReached;
    private Vector3 TargetPos;
    private Vector3 EnemyMovement;


    private Text questionsTxt;
    private int questionSet;


    public int answer;



    // Start is called before the first frame update
    void Start()
    {
        Hunting = false;
        isDestroy = false;
        playa = GameObject.FindWithTag("Player");
        HealthBa = GameObject.FindWithTag("HealthBar");

        hit = false;

        TargetReached = true;

        questionsTxt = gameObject.transform.Find("Canvas").transform.Find("Text").GetComponent<Text>();


        questionSet = Random.Range(0, 3);
        switch(questionSet) {
            case 0 : 
                T1Q1 q = new T1Q1();
                questionsTxt.text = q.a.ToString() + " + " + q.b.ToString();
                answer = q.ans;

            break;
            case 1 :
                
                T1Q2 q2 = new T1Q2();
                questionsTxt.text = q2.a.ToString() + " - " + q2.b.ToString();
                answer = q2.ans;

            break;
            case 2 :
                
                T1Q3 q3 = new T1Q3();
                questionsTxt.text = q3.a.ToString() + " x " + q3.b.ToString();
                answer = q3.ans;

            break;
            case 3 :
                
                T1Q4 q4 = new T1Q4();
                questionsTxt.text = q4.a.ToString() + " ÷ " + q4.b.ToString();
                answer = q4.ans;

            break;
        }





        
    }

    void EnemyTargeting()
    {
        xChange = Random.Range(-9, -7);
        yChange = Random.Range(-2, 2);
        
        TargetPos = new Vector3(xChange, yChange, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        HealthScript = HealthBa.GetComponent<Health>();
        
        TargetPos = playa.transform.position;

        EnemyMovement = TargetPos - transform.position;
        EnemyMovement.Normalize();

        EnemyMovement.y /= 2;

        transform.position += EnemyMovement * EnemySpeed * Time.deltaTime;

        if (isDestroy)
        {
            Destroy(gameObject);
        }




        /*if (TargetReached)
        {
            if (Hunting)
            {
                TargetPos = playa.transform.position;
            }
            else
            {
                EnemyTargeting();
            }
            TargetReached = false;
            //EnemyMovement.x = -(Mathf.Abs(TargetPos.x - transform.position.x) / 10);
            //EnemyMovement.y = ((TargetPos.y - transform.position.y) / 10);

            //EnemyMovement = TargetPos - transform.position;

            EnemyMovement.x = TargetPos.x - transform.position.x;
            EnemyMovement.y = TargetPos.y - transform.position.y;
            EnemyMovement.Normalize();


        }
        else
        {
            UnityEngine.Debug.Log(EnemyMovement.y);
            transform.position += EnemyMovement * EnemySpeed * Time.fixedDeltaTime;

            if (TargetPos.x - transform.position.x < 0.1 && TargetPos.y - transform.position.y < 0.1)
            {
                TargetReached = true;
            }
        }*/









    }

    void OnTriggerEnter2D(Collider2D colliding)
    {
        if(colliding.tag == "Checkpoint")
        {
            Hunting = true;
        }
        if(colliding.tag == "Player")
        {
            if (!hit)
            {
                HealthScript.hitCounter += 1;
                hit = true;
            }
            isDestroy = true;
        }
    }

}
