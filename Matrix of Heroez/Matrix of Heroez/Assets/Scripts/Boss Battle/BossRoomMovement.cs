using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BossRoomMovement: MonoBehaviour
{
    public float moveSpeed = 5f;

    private Animator anime;
    private Vector3 movement;
    private Rigidbody2D rb;

    private void Start()
    {
        anime = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement == new Vector3(0f, 0f, 0f))
            anime.SetInteger("Direction", 0);


        if (movement.y > 0f)
            anime.SetInteger("Direction", 1);

        if (movement.y < 0f)
            anime.SetInteger("Direction", 1);


    }

    void FixedUpdate()
    {
        transform.position += movement * moveSpeed * Time.fixedDeltaTime;
    }
}
