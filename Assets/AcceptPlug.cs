using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptPlug : MonoBehaviour
{
    public GameObject locationView;
    public GameObject data;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Plug"))
        {
            print("ENTER Plug");
            locationView.GetComponent<MoveToTarget>().isMoving = true;
            data.GetComponent<MoveToTarget>().isMoving = true;
            // other.GetComponent<GrabbableObject>().SetActive(false);
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
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
