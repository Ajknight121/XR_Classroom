using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTwo : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource doorSound;
    public Rigidbody doorRigidbody;
    public float bounceForce = 300f;

    void Start()
    {
        doorRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            doorRigidbody.velocity = Vector3.zero; // Stop bouncing
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorRigidbody.AddForce(Vector3.up * bounceForce);
            if (!doorSound.isPlaying) doorSound.Play();
        }
    }
}
