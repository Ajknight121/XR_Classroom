﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public Transform from;
    public Transform to;
    public float distancePerFrame;
    public bool isMoving;
    public bool isData;
    public bool played;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        played = false;

        if (!isData)
        {
            animator = GetComponent<Animator>();
            if (animator) {
                animator.StopPlayback();
            }
            transform.position = from.position;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            Vector3 direction = (to.position - from.position).normalized;
            float step = distancePerFrame * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, to.position, step);
            // if (isData) {
            //     transform.position.y = -6;
            // }
            if (played)
            {
                GetComponent<Animator>().Play("JapanView", -1, 0f);
            }
        }
    }
}
