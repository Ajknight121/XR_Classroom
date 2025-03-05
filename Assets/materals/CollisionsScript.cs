using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionsScript : MonoBehaviour
{

    public AudioClip mySound;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().PlayOneShot(mySound);
            Debug.Log("collide & play sound");
        }
    }
}