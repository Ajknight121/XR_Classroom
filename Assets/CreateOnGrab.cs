using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOnGrab : MonoBehaviour
{
    public float delay;
    public float maxDelay;
    public GrabbableObject obj;
    public GameObject spawnedPrefab;
    public Transform spawnLocation;
    // Start is called before the first frame update
    void Start()
    {
        obj = GetComponent<GrabbableObject>();
        Debug.Log(obj);
        delay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (obj.grabbed && delay <= 0) {
            GameObject newInstance;
            newInstance = Instantiate(spawnedPrefab, spawnLocation.position,
            spawnLocation.rotation);
            newInstance.GetComponent<Rigidbody>().AddForce(spawnLocation.forward * 50);
            
            delay = maxDelay;
        }
        delay -= 1 * Time.deltaTime;
    }
}
