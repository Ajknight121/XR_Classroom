using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchonTrigTest : MonoBehaviour
{
    public GameObject baseObjects;
    public GameObject changedObjectsPrefab;

    private GameObject currentChangedObject; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            baseObjects.SetActive(false);

            if (currentChangedObject == null && changedObjectsPrefab != null)
            {
                Vector3 manualPosition = new Vector3(9.22f, -4.59f, 30.36f);

                currentChangedObject = Instantiate(changedObjectsPrefab, manualPosition, baseObjects.transform.rotation);
                currentChangedObject.transform.SetParent(null);
                currentChangedObject.transform.localScale = baseObjects.transform.localScale;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            baseObjects.SetActive(true);

            if (currentChangedObject != null)
            {
                Destroy(currentChangedObject);
                currentChangedObject = null;
            }
        }
    }

}

