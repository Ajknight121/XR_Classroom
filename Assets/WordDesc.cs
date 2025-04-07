using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class WordDesc : MonoBehaviour
{
    public string word;

    public float scale;

    public WordDesc(string word, float scale)
    {
        this.word = word;
        this.scale = scale;
    }
}