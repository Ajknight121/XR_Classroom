using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceWords : MonoBehaviour
{
    public List<GameObject> prefabLetters;
    public List<string> words = new List<string>();
    
    public bool onStart = false;
    public float scale = 1f;
    public Quaternion rotation = new Quaternion();
    public Vector3 wordOffset = new Vector3(10f, 0f, 10f);
    public Vector3 currWordOffset = new Vector3(0f, 0f, 0f);
    public float letterSpacing = 1.1f;
    public bool hasGravity = false;
    public Material material;
    public Dictionary<char, int> letterToIndex = new Dictionary<char, int>();
    void Start()
    {
        // Populate dictionary (A-Z mapped to 0-25)
        for (int i = 0; i < 26; i++)
        {
            letterToIndex.Add((char)('A' + i), i);
        }
        Physics.IgnoreLayerCollision(8, 9, true);
        if (onStart)
        {
            PlaceAllWords(words, 999);
        }
    }

    public void PlaceAllWords(List<string> words, float lifetime)
    {
        
        
        currWordOffset = Vector3.zero;
        // Instantiate words with spacing
        foreach (var word in words)
        {
            print(word);
            float xOffset = 0f; // Reset X offset for each word
            
            // Create an empty parent object for the word
            GameObject wordObject = new GameObject(word);
            
            wordObject.transform.position = transform.position + currWordOffset;
            wordObject.transform.SetParent(transform); // Parent to this script’s GameObject
            wordObject.layer = LayerMask.NameToLayer("TextGap");
            
            print(transform.position);
            
            // Phsyics on the word
            Rigidbody wordRigidbody = wordObject.AddComponent<Rigidbody>();
            wordRigidbody.isKinematic = false; // Let the physics system control this object
            wordRigidbody.mass = 2.0f;
            wordRigidbody.drag = 1.87f;
            wordRigidbody.angularDrag = .5f;
            wordRigidbody.useGravity = hasGravity;
            
            foreach (var letter in word)
            {
                
                if (letterToIndex.ContainsKey(letter)) // Ensure valid letter
                {
                    Vector3 spawnPosition = wordObject.transform.position + new Vector3(xOffset, 0, 0);
                    GameObject letterObj = Instantiate(prefabLetters[letterToIndex[letter]], spawnPosition, Quaternion.identity, wordObject.transform);
                    letterObj.layer = LayerMask.NameToLayer("TextGap");
                    letterObj.transform.localScale = new Vector3(scale, scale, scale);
                    if (material)
                    {
                        letterObj.GetComponent<Renderer>().material = material;
                    }
                    xOffset -= letterSpacing; // Increase offset for next letter
                }
            }

            currWordOffset += wordOffset;

            // Add a collider, grabbable and rotate now that all letters are present
            // rotate not well implemented?
            AddColliderToWord(wordObject);
            wordObject.AddComponent<GrabbableObject>();
            wordObject.GetComponent<GrabbableObject>().showTouchingOver = false;
            wordObject.GetComponent<GrabbableObject>().showPointingOver = false;
            wordObject.transform.rotation = transform.rotation;
            wordObject.transform.rotation = rotation;
            StartCoroutine(DestroyObjectAfterTime(wordObject,lifetime));
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
    
    private IEnumerator DestroyObjectAfterTime(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(obj);
    }
}
