using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wordSpawner : MonoBehaviour
{
    public float currentDelay = 0f;
    public float maxDelay = 3f;

    public int index = 0;
    public List<string> words = new List<string>();
    
    public float scale = 1f;
    public Vector3 wordOffset = new Vector3(10f, 0f, 10f);
    public Vector3 currWordOffset = new Vector3(0f, 0f, 0f);
    public float letterSpacing = 1.1f;
    public PlaceWords placewords;
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        currentDelay += Time.deltaTime;
        if (currentDelay >= maxDelay)
        {
            index = index % words.Count;
            currentDelay = 0f;
            List<string> wordSpawn = new List<string>();
            
            wordSpawn.AddRange(words[index].Split(' '));
            placewords.PlaceAllWords(wordSpawn, lifetime);
            index++;
        }
    }
    
    
}

