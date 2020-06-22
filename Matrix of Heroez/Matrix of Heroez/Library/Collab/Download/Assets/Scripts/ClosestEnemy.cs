using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosestEnemy : MonoBehaviour


{
    public GameObject[] enemies;
    public GameObject Boss;
    public GameObject Reticle;
    public GameObject question; 
    private float NearestDist;
    private GameObject closest;
    private bool bore;
    private bool haveClosest;
    private GameObject targeted;


    // Start is called before the first frame update
    void Start()
    {
        Boss = GameObject.FindWithTag("Boss");
        bore = false;
    
        NearestDist = Mathf.Infinity;
        haveClosest = false;
    }

    // Update is called once per frame
    void Update()
    {

        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (!(haveClosest))
        {
            targeted = FindClosest();
            haveClosest = true;
        }
        if (!(targeted == null))
        {
            UnityEngine.Debug.Log(targeted.transform.position);
            Instantiate(question, targeted.transform.position, transform.rotation);
            Instantiate(Reticle, targeted.transform.position, transform.rotation);
        }
        else
        {
            haveClosest = false;
        }


    }

    public GameObject FindClosest()
    {
        NearestDist = Mathf.Infinity;
        foreach (GameObject enemy in enemies)
        {
            if (NearestDist > Vector3.Distance(transform.position, enemy.transform.position))
            {
                NearestDist = Vector3.Distance(transform.position, enemy.transform.position);
                closest = enemy;
            }
        }
        return closest;
    }

}
