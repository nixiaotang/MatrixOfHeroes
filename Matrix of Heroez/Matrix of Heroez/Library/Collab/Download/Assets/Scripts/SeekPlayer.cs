using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekPlayer : MonoBehaviour
{

    [SerializeField] public bool Hunting;
    public int EnemySpeed;
    public GameObject playa;


    private float xChange;
    private float yChange;
    [SerializeField]  private bool TargetReached;
    private Vector3 TargetPos;
    private Vector3 EnemyMovement;



    // Start is called before the first frame update
    void Start()
    {
        Hunting = false;
        playa = GameObject.FindWithTag("Player");
        TargetReached = true;
        
    }

    void EnemyTargeting()
    {
        xChange = Random.Range(-9, -7);
        yChange = Random.Range(-2, 2);
        
        TargetPos = new Vector3(xChange, yChange, 0f);

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        
        TargetPos = playa.transform.position;

        EnemyMovement = TargetPos - transform.position;
        EnemyMovement.Normalize();

        EnemyMovement.y /= 15;

        transform.position += EnemyMovement * EnemySpeed * Time.deltaTime;






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
            Destroy(gameObject);
        }
    }

}
