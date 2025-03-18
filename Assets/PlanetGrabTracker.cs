using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGrabTracker : MonoBehaviour
{
    private Dictionary<string, GrabPlanet> planetComponents;
    public GameObject blackHole;

    public bool earthGrabbed = false;
    public bool jupiterGrabbed = false;
    public bool marsGrabbed = false;
    public bool mercuryGrabbed = false;
    public bool saturnGrabbed = false;
    public bool uranusGrabbed = false;
    public bool venusGrabbed = false;
    public bool neptuneGrabbed = false;
    public bool sunGrabbed = false;

    public float suckSpeed = 100.0f;
    public float shrinkSpeed = 0.1f;
    public float shrinkThreshold = 5.0f;

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

        blackHole = GameObject.Find("black hole");
    }

    // Update is called once per frame
    void Update()
    {
        earthGrabbed = planetComponents["Earth"].isGrabbed;
        jupiterGrabbed = planetComponents["Jupiter"].isGrabbed;
        marsGrabbed = planetComponents["Mars"].isGrabbed;
        mercuryGrabbed = planetComponents["Mercury"].isGrabbed;
        saturnGrabbed = planetComponents["Saturn"].isGrabbed;
        uranusGrabbed = planetComponents["Uranus"].isGrabbed;
        venusGrabbed = planetComponents["Venus"].isGrabbed;
        neptuneGrabbed = planetComponents["Neptune"].isGrabbed;
        sunGrabbed = planetComponents["Sun"].isGrabbed;

        if (blackHole != null)
        {
            Vector3 blackHolePosition = blackHole.transform.position;

            if (earthGrabbed && jupiterGrabbed && marsGrabbed && mercuryGrabbed && saturnGrabbed && uranusGrabbed && venusGrabbed && neptuneGrabbed && sunGrabbed)
            {
                foreach (var planet in planetComponents)
                {
                    Transform planetTransform = planet.Value.transform;
                    planetTransform.position = Vector3.MoveTowards(planetTransform.position, blackHolePosition, suckSpeed * Time.deltaTime);

                    if (Vector3.Distance(planetTransform.position, blackHolePosition) < shrinkThreshold)
                    {
                        planetTransform.localScale = Vector3.Lerp(planetTransform.localScale, Vector3.zero, shrinkSpeed * Time.deltaTime);
                    }
                }

                Transform sunTransform = planetComponents["Sun"].transform;
                if (sunTransform.localScale.x <= 0.3f && sunTransform.localScale.y <= 0.3f && sunTransform.localScale.z <= 0.3f)
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene("HubClassroom");
                }
            }
        }
    }
}
