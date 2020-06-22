using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class BossMovement : MonoBehaviour
{

    public bool IsStunned;
    private Vector3 BossPosition;
    private float BossMovementRate;
    private Rigidbody2D rigid;


    // Start is called before the first frame update
    void Start()
    {
        IsStunned = false;
        BossMovementRate = 1.5f;
        rigid = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        BossPosition.x = -1*BossMovementRate;
        transform.position += BossPosition * Time.fixedDeltaTime;
    }

    void OnTriggerEnter2D(Collider2D colliding)
    {

        if (colliding.tag == "Lose")
        {
            transform.position = new Vector3(17f, 0.95f, 0f);
        }
    }
}
