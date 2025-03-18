using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGrabTracker : MonoBehaviour
{
    private Dictionary<string, GrabPlanet> planetComponents;

    public bool earthGrabbed = false;
    public bool jupiterGrabbed = false;
    public bool marsGrabbed = false;
    public bool mercuryGrabbed = false;
    public bool saturnGrabbed = false;
    public bool uranusGrabbed = false;
    public bool venusGrabbed = false;
    public bool neptuneGrabbed = false;
    public bool sunGrabbed = false;

    // Start is called before the first frame update
    void Start()
    {
        planetComponents = new Dictionary<string, GrabPlanet>
        {
            { "Earth", GameObject.Find("Earth").GetComponent<GrabPlanet>() },
            { "Jupiter", GameObject.Find("Jupiter").GetComponent<GrabPlanet>() },
            { "Mars", GameObject.Find("Mars").GetComponent<GrabPlanet>() },
            { "Mercury", GameObject.Find("Mercury").GetComponent<GrabPlanet>() },
            { "Saturn", GameObject.Find("Saturn").GetComponent<GrabPlanet>() },
            { "Uranus", GameObject.Find("Uranus").GetComponent<GrabPlanet>() },
            { "Venus", GameObject.Find("Venus").GetComponent<GrabPlanet>() },
            { "Neptune", GameObject.Find("Neptune").GetComponent<GrabPlanet>() },
            { "Sun", GameObject.Find("Sun").GetComponent<GrabPlanet>() }
        };
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var planet in planetComponents)
        {
            Debug.Log($"{planet.Key} isGrabbed: {planet.Value.isGrabbed}");
        }

        earthGrabbed = planetComponents["Earth"].isGrabbed;
        jupiterGrabbed = planetComponents["Jupiter"].isGrabbed;
        marsGrabbed = planetComponents["Mars"].isGrabbed;
        mercuryGrabbed = planetComponents["Mercury"].isGrabbed;
        saturnGrabbed = planetComponents["Saturn"].isGrabbed;
        uranusGrabbed = planetComponents["Uranus"].isGrabbed;
        venusGrabbed = planetComponents["Venus"].isGrabbed;
        neptuneGrabbed = planetComponents["Neptune"].isGrabbed;
        sunGrabbed = planetComponents["Sun"].isGrabbed;
    }
}
