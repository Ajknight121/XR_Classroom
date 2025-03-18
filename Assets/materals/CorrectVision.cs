using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CorrectVision : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI letterText;
    private bool isBlurred = true;


    void Start()
    {
        letterText = GetComponent<TextMeshProUGUI>();
        BlurLetter();
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        isBlurred = !isBlurred;
        letterText.fontSize = isBlurred ? 10f : 50f;
        letterText.alpha = isBlurred ? 0.3f : 1f;
    }

    void BlurLetter()
    {
        letterText.fontSize = 10f;
        letterText.alpha = 0.3f;
    }

}
