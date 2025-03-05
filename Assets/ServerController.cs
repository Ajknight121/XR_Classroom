using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerController : MonoBehaviour
{
    public GameObject locationView;
    public GameObject data;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("ENTER Player");
            locationView.GetComponent<MoveToTarget>().isMoving = true;
            data.GetComponent<MoveToTarget>().isMoving = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("STAY Player");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("LEAVE Player");
        }
        locationView.GetComponent<MoveToTarget>().isMoving = false;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
