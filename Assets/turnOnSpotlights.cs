using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOnSpotlights : MonoBehaviour
{
    public GameObject spotlightToTurnOff;
    public GameObject spotlight1;
    public GameObject spotlight2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
 
        spotlightToTurnOff.SetActive(false);
        spotlight1.SetActive(true);
        spotlight2.SetActive(true);
    }
}
