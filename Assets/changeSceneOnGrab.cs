using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeSceneOnGrab : MonoBehaviour
{
    private GrabbableObject grabTarget;
    public string sceneTitle;
    public Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        grabTarget = GetComponent<GrabbableObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grabTarget.grabbed)
        {
            SceneManager.LoadScene(sceneTitle);
            
        }
    }
}
