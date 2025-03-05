using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public Transform from;
    public Transform to;
    public float distancePerFrame;
    public bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = from.position;
    }


    // Update is called once per frame
    void Update()
    {
        if (isMoving) {
            Vector3 direction = (to.position - from.position).normalized;
            float step = distancePerFrame * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, to.position, step);
        }
    }
}
