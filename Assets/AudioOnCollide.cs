using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioOnCollide : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public float maxDelay = 0.5f;
    public float currentDelay = 0;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("TextGap"))
        {
            // audioSource.Stop();
            if (currentDelay <= 0)
            {
                currentDelay = maxDelay;
                audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
            }
            // audioSource.Play();
        }
    }
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentDelay -= Time.deltaTime;
    }
}
