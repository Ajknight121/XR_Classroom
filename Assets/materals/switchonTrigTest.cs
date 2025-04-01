using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchonTrigTest : MonoBehaviour
{
    // Assign Red Square (original object) in the Inspector
    public GameObject baseObjects;
    // Assign Green Circle (replacement object prefab) in the Inspector
    public GameObject changedObjectsPrefab;

    private GameObject currentChangedObject;  // Track the current instantiated object

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure Player is the one triggering it
        {
            // Disable the base object (Red Square)
            baseObjects.SetActive(false);

            // Instantiate the changed object (Green Circle) at a manually specified position
            if (currentChangedObject == null && changedObjectsPrefab != null)
            {
                // Specify the manual position you want (x, y, z)
                Vector3 manualPosition = new Vector3(9.22f, -4.59f, 30.36f);

                // Instantiate the prefab at the manually specified position and the same rotation as the base object
                currentChangedObject = Instantiate(changedObjectsPrefab, manualPosition, baseObjects.transform.rotation);

                // Optionally, you can add a small delay to help debug
                Debug.Log("New Object Position (Manually set): " + currentChangedObject.transform.position);

                // Make sure the object is not parented to anything, or set parent if necessary
                currentChangedObject.transform.SetParent(null);  // Remove parent temporarily

                // Optionally, ensure that the scale and rotation match the base object
                currentChangedObject.transform.localScale = baseObjects.transform.localScale;

                // Log final position to verify
                Debug.Log("Final Position after Instantiation: " + currentChangedObject.transform.position);
            }
            else
            {
                Debug.LogWarning("Changed Objects Prefab not assigned in the Inspector!");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Restore the base object (Red Square)
            baseObjects.SetActive(true);

            // Destroy the changed object (Green Circle) if it exists
            if (currentChangedObject != null)
            {
                Destroy(currentChangedObject);
                currentChangedObject = null;
            }
        }
    }
}

