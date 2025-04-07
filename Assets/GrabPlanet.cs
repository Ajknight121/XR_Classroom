using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabPlanet : MonoBehaviour
{
    public GameObject typography;
    public string typeName;

    public GameObject planet;
    public string planetName;

    public float typeSize;
    public float typeNewSize;
    public float typeEnlargeRate = 10f;

    public GameObject wand; // Reference to the Wand gameobject
    public bool isGrabbed = false; // Flag to check if the planet is grabbed
    public bool isPointing = false; // Flag to check if the planet is being pointed at
    public float raycastDistance = 10000f; // Maximum distance for the raycast

    public float delay = 0.0f; // Delay in seconds
    private float timer = 0.0f; // Timer to track elapsed time

    // Start is called before the first frame update
    void Start()
    {
        typography = GameObject.Find(typeName);
        if (typography == null)
        {
            Debug.LogError(typeName + " gameobject not found!");
        }
        else
        {
            typography.transform.localScale = new Vector3(typeSize, typeSize, typeSize);
        }

        planet = GameObject.Find(planetName);
        if (planet == null)
        {
            Debug.LogError(planetName + " gameobject not found!");
        }

        wand = GameObject.Find("Wand"); // Assuming the Wand gameobject is named "Wand"
        if (wand == null)
        {
            Debug.LogError("Wand gameobject not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (wand != null && planet != null)
        {
            Ray ray = new Ray(wand.transform.position, wand.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, raycastDistance))
            {
                if (hit.collider.gameObject == planet)
                {
                    Debug.Log("Wand is pointing at the planet!");
                    isPointing = true;
                }
                else
                {
                    isPointing = false;
                }
            }
            else
            {
                isPointing = false;
            }
        }

        if (isPointing)
        {
                isGrabbed = true;
                
                if (typography.transform.localScale.x < typeNewSize)
                    typography.transform.localScale = new Vector3(typography.transform.localScale.x + typeEnlargeRate, typography.transform.localScale.y + typeEnlargeRate, typography.transform.localScale.z + typeEnlargeRate);
                timer = 0.0f; // Reset the timer after the action is performed
        }
        else
        {
            timer = 0.0f; // Reset the timer if not pointing at the planet
        }
    }
}
