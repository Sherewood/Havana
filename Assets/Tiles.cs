using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    public Tiles[] neighbors;
    Color color;
    bool pressed;
    float size;
    float height;
    float width;
    float horiz;
    float vert;
    string name;
    // Start is called before the first frame update
    void Start()
    {

        size = 2;
        width = size * Mathf.Sqrt(3);
        height = size * 2;
        horiz = width;
        vert = 3/4* height;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
