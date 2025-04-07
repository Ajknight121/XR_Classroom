using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    public GameObject player;
    
    void Start()
    {
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            print("ENTER Player");
            // locationView.GetComponent<MoveToTarget>().isMoving = true;
            // player.ReadHardCollision(this.gameObject, other);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            print("STAY Player");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            print("LEAVE Player");
        }
    }
}
