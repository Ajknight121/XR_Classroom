using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSound : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource doorSound;
    private bool isRotating = false;

    void Update()
    {
        if (isRotating)
        {
            transform.Rotate(0, 50 * Time.deltaTime, 0);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isRotating = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isRotating = true;
            doorSound.Play();
        }
    }
}
