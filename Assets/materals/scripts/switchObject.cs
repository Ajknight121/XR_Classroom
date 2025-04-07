using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchObject : MonoBehaviour
{
    public GameObject newObjectPrefab; 
    public CAVE2.Button switchButton = CAVE2.Button.Button3; 
    public float newScale = 0.5f;

    void Update()
    {
        if (CAVE2.Input.GetButtonDown(1, switchButton)) 
        {
            ChangeObject();
        }
    }

    void ChangeObject()
    {
        if (newObjectPrefab != null)
        {
            Transform originalParent = transform.parent;

            Vector3 originalPosition = transform.position;
            Quaternion originalRotation = transform.rotation;

            GameObject newObject = Instantiate(newObjectPrefab, originalPosition, originalRotation);
            newObject.transform.localScale = new Vector3(newScale, newScale, newScale);

            if (originalParent != null)
            {
                newObject.transform.SetParent(originalParent, true); 
            }
            else
            {
                GameObject parentObject = GameObject.Find("bevelPolygon1");
                if (parentObject != null)
                {
                    newObject.transform.SetParent(parentObject.transform, true);
                }
            }

            newObject.transform.localScale = new Vector3(newScale, newScale, newScale);
            Destroy(gameObject);
        }
    }

}
