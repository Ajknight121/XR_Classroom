using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject doorPrefab; // Assign your door prefab in the Inspector
    public Transform spawnPoint; // Where the new door should appear

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Press Space to spawn a door
        {
            Instantiate(doorPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
