using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChange : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject newObjectPrefab; // Assign in Inspector
    public string targetTag = "SwitchTrigger"; // Tag of the object to collide with
    private GameObject currentObject;
    private GameObject replacedObject;

    private void Start()
    {
        currentObject = gameObject; // Store reference to the original object
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag) && newObjectPrefab != null && replacedObject == null)
        {
            SwapObject();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag) && replacedObject != null)
        {
            RestoreObject();
        }
    }

    void SwapObject()
    {
        Vector3 originalPosition = currentObject.transform.position;
        Quaternion originalRotation = currentObject.transform.rotation;
        Transform originalParent = currentObject.transform.parent;

        replacedObject = Instantiate(newObjectPrefab, originalPosition, originalRotation);
        replacedObject.transform.SetParent(originalParent, true);
        replacedObject.transform.localScale = currentObject.transform.localScale;

        currentObject.SetActive(false);
    }

    void RestoreObject()
    {
        if (replacedObject != null)
        {
            Destroy(replacedObject);
            currentObject.SetActive(true);
            replacedObject = null;
        }
    }
}
