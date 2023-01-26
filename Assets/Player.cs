using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class Player : MonoBehaviour
{
    public bool Active;
    public Color player_color;
    public float moveSpeed = 0.1f;
    public bool AI = false;
    // Start is called before the first frame update
    void Start()
    {
        Active = true;
        //player_color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (Active)
        {
           if (!AI)
            {
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 100;
                this.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
            }
       /*    else
            {
                this.transform.position = new Vector3(10, 10, 10);
              //  randoAI();
            }*/

        }
        else
        {
           
            Vector3 pos=new Vector3 (-10000f, -10000f, -10000f);
            this.transform.position = pos;
        }
 

        this.GetComponent<MeshRenderer>().material.color = player_color;
    }
    private void randoAI()
    {
       

        
    }
    //Debug.Log(transform.position + " THIS SHOULD WORK");




}
