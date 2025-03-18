using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shakFull : MonoBehaviour
{
    // Start is called before the first frame update
    public float shakeAmountX = 0.1f; // Side-to-side shake amount
    public float shakeAmountY = 0.1f; // Up-and-down shake amount
    public float shakeSpeed = 5f;     // Speed of shaking

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
