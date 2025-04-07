using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassesTrigger : MonoBehaviour
{
    public AudioSource ambientSource;
    public AudioSource altAmbientSource;
    public AudioSource glassesSFX;

    private bool hasPlayedCollisionSound = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!hasPlayedCollisionSound)
            {
                glassesSFX.Play();
                hasPlayedCollisionSound = true;
            }

            if (ambientSource.isPlaying)
                ambientSource.Stop();

            if (!altAmbientSource.isPlaying)
                altAmbientSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (altAmbientSource.isPlaying)
                altAmbientSource.Stop();

            if (!ambientSource.isPlaying)
                ambientSource.Play();
        }
    }

}
