using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchObject : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject newObjectPrefab; // Drag your Prefab here in the Inspector
    public CAVE2.Button switchButton = CAVE2.Button.Button3; // Change this if needed
    public float newScale = 0.5f;

    void Update()
    {
        if (CAVE2.Input.GetButtonDown(1, switchButton)) // '1' is the Wand ID
        {
            ChangeObject();
        }
    }

    void ChangeObject()
    {
        if (newObjectPrefab != null)
        {
            // Store the original object's parent before destruction
            Transform originalParent = transform.parent;

            // Store position, rotation, and scale
            Vector3 originalPosition = transform.position;
            Quaternion originalRotation = transform.rotation;
            Vector3 originalScale = transform.localScale;

            // Instantiate the new object at the same position & rotation
            GameObject newObject = Instantiate(newObjectPrefab, originalPosition, originalRotation);
            newObject.transform.localScale = new Vector3(newScale, newScale, newScale);

            Debug.Log("New object instantiated: " + newObject.name);
            Debug.Log("Original Parent: " + (originalParent != null ? originalParent.name : "None"));

            // Ensure the new object is placed inside "bevelPolygon1"
            if (originalParent != null)
            {
                newObject.transform.SetParent(originalParent, true); // Keeps world position
                Debug.Log("Assigned parent: " + newObject.transform.parent.name);
            }
            else
            {
                // If original parent is missing, manually find and assign "bevelPolygon1"
                GameObject parentObject = GameObject.Find("bevelPolygon1");
                if (parentObject != null)
                {
                    newObject.transform.SetParent(parentObject.transform, true);
                    Debug.Log("Assigned bevelPolygon1 as parent.");
                }
                else
                {
                    Debug.LogWarning("Parent 'bevelPolygon1' not found in the scene!");
                }
            }

            // Destroy the old object
            newObject.transform.localScale = new Vector3(newScale, newScale, newScale);

            Destroy(gameObject);
        }
        else
        {
            Debug.LogWarning("New object prefab is not assigned in the Inspector!");
        }

    }
}
