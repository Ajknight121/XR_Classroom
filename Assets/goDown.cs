using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goDown : MonoBehaviour
{
    public float speed = 1f;
    public float stopYValue = -5f;
    public float moveXValue = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y <= stopYValue)
            return;
        transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);

        if (moveXValue > 0 || moveXValue < 0)
        {
            transform.position = new Vector3(transform.position.x + moveXValue * Time.deltaTime, transform.position.y, transform.position.z);
            moveXValue -= moveXValue * Time.deltaTime;
        }
    }
}
