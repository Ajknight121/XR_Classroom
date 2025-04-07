using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpinForce : MonoBehaviour
{
    public float torqueForce;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            Rigidbody rb = child.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 randomTorque = new Vector3(
                    Random.Range(-1f, 1f),
                    Random.Range(-1f, 1f),
                    Random.Range(-1f, 1f)
                ).normalized * torqueForce;

                rb.AddTorque(randomTorque, ForceMode.Impulse);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
