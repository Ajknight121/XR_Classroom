using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shakFull : MonoBehaviour
{
    public float shakeAmountX = 0.1f;
    public float shakeAmountY = 0.1f; 
    public float shakeSpeed = 5f;     

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float offsetX = Mathf.Sin(Time.time * shakeSpeed) * shakeAmountX;
        float offsetY = Mathf.Cos(Time.time * shakeSpeed) * shakeAmountY;
        transform.position = startPosition + new Vector3(offsetX, offsetY, 0);
    }

}
