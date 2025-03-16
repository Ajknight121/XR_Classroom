using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public Transform object1;
    public Transform object2;
    private LineRenderer lineRenderer;
    public float width;
    // Start is called before the first frame update
    void Start() {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2; // Only two points needed
        lineRenderer.startWidth = 1f;
        lineRenderer.endWidth = 1f;
    }

    void Update() {
        if (object1 != null && object2 != null) {
            lineRenderer.SetPosition(0, object1.position); // Start point
            lineRenderer.SetPosition(1, object2.position); // End point
        }
    }
}
