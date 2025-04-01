using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorThree : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem doorParticles;

    void Start()
    {
        if (doorParticles == null)
            doorParticles = GetComponentInChildren<ParticleSystem>();
    }

    void OnMouseDown()
    {
        if (doorParticles != null)
        {
            doorParticles.Play();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (doorParticles != null)
            {
                doorParticles.Play();
            }
        }
    }
}
