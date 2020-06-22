using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class InstantiateEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer;
    private float SpawnRate;
    private float height;
    private Vector3 spawn;


    public GameObject EnemyOne;

    void Start()
    {
        timer = 0;
        SpawnRate = 2.5f;

    }

    public Vector3 RandomSpawnPos()
    { 
        
        height = Random.Range(-3f,3f);

        spawn = new Vector3(9f, height, 0f);

        return spawn;

        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > SpawnRate)
        {
            Instantiate(EnemyOne, RandomSpawnPos(), transform.rotation);
            timer = 0;

        }
    }
}
