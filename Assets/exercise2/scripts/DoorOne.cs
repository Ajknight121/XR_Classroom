using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOne : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource doorSound;
    public Material transparentMaterial;
    public Vector3 scaleFactor = new Vector3(1.2f, 1.2f, 1f);
    private Vector3 originalScale;
    private Renderer doorRenderer;
    private Material originalMaterial;

    void Start()
    {
        doorRenderer = GetComponent<Renderer>();
        originalMaterial = doorRenderer.material;
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            transform.localScale = originalScale; // Reset scale
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorRenderer.material = transparentMaterial; // Make door semi-transparent
        }
    }

    void OnTriggerExit(Collider other)
    {
        doorRenderer.material = originalMaterial; // Restore original material
    }

    void OnMouseDown()
    {
        transform.localScale *= 1.2f; // Increase size when clicked
        if (!doorSound.isPlaying) doorSound.Play();
    }

}
