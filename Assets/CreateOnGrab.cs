using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOnGrab : MonoBehaviour
{
    public float delay;
    public float maxDelay;
    private GrabbableObject grabTarget;
    public GameObject spawnedPrefab;
    public Transform spawnLocation;
    // Start is called before the first frame update
    void Start()
    {
        grabTarget = GetComponent<GrabbableObject>();
        Debug.Log(grabTarget);
        delay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (grabTarget.grabbed && delay <= 0) {
            GameObject newInstance;
            newInstance = Instantiate(spawnedPrefab, spawnLocation.position,
            spawnLocation.rotation);
            newInstance.GetComponent<Rigidbody>().AddForce(spawnLocation.forward * 50);
            
            delay = maxDelay;
        }
        delay -= 1 * Time.deltaTime;
    }
}
