using System.Collections.Generic;
using UnityEngine;

public class PlaceWords : MonoBehaviour
{
    public List<GameObject> prefabLetters;
    public List<string> words = new List<string>();
    
    public float scale = 1f;
    public Quaternion rotation = new Quaternion();
    public Vector3 wordOffset = new Vector3(10f, 0f, 10f);
    public Vector3 currWordOffset = new Vector3(0f, 0f, 0f);
    public float letterSpacing = 1.1f;

    void Start()
    {
        Dictionary<char, int> letterToIndex = new Dictionary<char, int>();

        // Populate dictionary (A-Z mapped to 0-25)
        for (int i = 0; i < 26; i++)
        {
            letterToIndex.Add((char)('A' + i), i);
        }

        // Instantiate words with spacing
        foreach (var word in words)
        {
            float xOffset = 0f; // Reset X offset for each word
            
            // Create an empty parent object for the word
            GameObject wordObject = new GameObject(word);
            wordObject.transform.position = transform.position + currWordOffset;
            
            wordObject.transform.SetParent(transform); // Parent to this script’s GameObject
            
            // Phsyics on the word
            Rigidbody wordRigidbody = wordObject.AddComponent<Rigidbody>();
            wordRigidbody.isKinematic = false; // Let the physics system control this object
            wordRigidbody.mass = 2.0f;
            wordRigidbody.drag = 1.17f;
            wordRigidbody.angularDrag = .5f;
            wordRigidbody.useGravity = false;
            
            foreach (var letter in word)
            {
                if (letterToIndex.ContainsKey(letter)) // Ensure valid letter
                {
                    Vector3 spawnPosition = wordObject.transform.position + new Vector3(xOffset, 0, 0);
                    GameObject letterObj = Instantiate(prefabLetters[letterToIndex[letter]], spawnPosition, Quaternion.identity, wordObject.transform);

                    letterObj.transform.localScale = new Vector3(scale, scale, scale);

                    xOffset -= letterSpacing; // Increase offset for next letter
                }
            }

            currWordOffset += wordOffset;

            // Add a collider, grabbable and rotate now that all letters are present
            // rotate not well implemented?
            AddColliderToWord(wordObject);
            wordObject.AddComponent<GrabbableObject>();
            wordObject.GetComponent<GrabbableObject>().showTouchingOver = true;
            wordObject.GetComponent<GrabbableObject>().showPointingOver = true;
            wordObject.transform.rotation = transform.rotation;
            wordObject.transform.rotation = rotation;
        }
    }

    void AddColliderToWord(GameObject wordObject)
    {
        BoxCollider boxCollider = wordObject.AddComponent<BoxCollider>();

        // Calculate bounds based on children
        Bounds bounds = new Bounds(wordObject.transform.position, Vector3.zero);
        foreach (Transform child in wordObject.transform)
        {
            Renderer childRenderer = child.GetComponent<Renderer>();
            if (childRenderer != null)
            {
                bounds.Encapsulate(childRenderer.bounds);
            }
        }

        // Apply the calculated bounds to the BoxCollider
        boxCollider.center = bounds.center - wordObject.transform.position;
        boxCollider.size = bounds.size;
        
    }
}
