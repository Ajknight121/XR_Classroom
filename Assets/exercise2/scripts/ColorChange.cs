using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    // Start is called before the first frame update
        public Material doorMaterial1;
        public Material doorMaterial2;
        public Material doorMaterial3;

        void Update()
        {
            if (Input.GetMouseButtonDown(0)) // Left Click
            {
                GetComponent<Renderer>().material = doorMaterial1;
            }
            if (Input.GetMouseButtonDown(1)) // Right Click
            {
                GetComponent<Renderer>().material = doorMaterial2;
            }
            if (Input.GetMouseButtonDown(2)) // Middle Click
            {
                GetComponent<Renderer>().material = doorMaterial3;
            }

        }

    }
