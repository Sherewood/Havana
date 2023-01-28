using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    public List<Tiles>  neighbors= new List<Tiles>();
 public   Color color;
    bool pressed;
    float size;
    float height;
    float width;
    bool isclicked;
 public   bool drawn = false;
  public  float horiz;
  public  float vert;
    public bool corner;
    public bool marked =false;
    public (bool, int) edge;
    public bool edgeTest;
    public int edgeValTest;
    
    // Start is called before the first frame update
    void Start()
    {
      
        color = Color.white;
        size = 2;
        width = size * Mathf.Sqrt(3);
        height = size * 2;
        horiz = width;
        vert = (.75f)* height;
      
        this.GetComponentInChildren<MeshRenderer>().material.DisableKeyword("_EMISSION");
        

    }

    // Update is called once per frame
    void Update()
    {
        edgeTest = edge.Item1;
        edgeValTest = edge.Item2;
    }
    void OnMouseDown()
    {
        ColorSet();
    }
    public void ColorSet()
    {
        
        if (GameObject.Find("Game_Master").GetComponent<Game_Master>().game && color == Color.white)
        {
            color = GameObject.Find("Game_Master").GetComponent<Game_Master>().SetColor();
            GameObject.Find("Game_Master").GetComponent<Game_Master>().SwapPlayers();
            this.GetComponentInChildren<MeshRenderer>().material.color = color;
            this.isclicked = true;
            this.isclicked = true;
   

            // Code here is called when the GameObject is clicked on.
        }

    }
    private void OnMouseOver()
    {
        if (GameObject.Find("Game_Master").GetComponent<Game_Master>().game) this.GetComponentInChildren<MeshRenderer>().material.EnableKeyword("_EMISSION");
       
    }
    private void OnMouseExit()
    {
        if (GameObject.Find("Game_Master").GetComponent<Game_Master>().game) this.GetComponentInChildren<MeshRenderer>().material.DisableKeyword("_EMISSION");

    }

}
