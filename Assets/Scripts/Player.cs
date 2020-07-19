using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float cellSize = 16;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        Vector2 newVC = new Vector2(0.0f,0.0f); //new Vector2(0.0f,GetComponent<Rigidbody2D>().velocity.y);
        if (Input.GetKey(KeyCode.A))
        {
            newVC += new Vector2(-cellSize, 0.0f);//*Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            newVC += new Vector2(cellSize, 0.0f);//*Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            newVC += new Vector2(0.0f, cellSize);//*Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            newVC += new Vector2(0.0f, -cellSize);//*Time.deltaTime;
        }
        GetComponent<Rigidbody2D>().velocity = newVC;
    }
}
