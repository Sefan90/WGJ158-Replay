using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 4;
    float jumpspeed = 2.5f;
    bool ground = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        Vector2 newVC = new Vector2(0.0f,GetComponent<Rigidbody2D>().velocity.y); //new Vector2(0.0f,0.0f); //

        if (ground == true)
        {
            newVC = new Vector2(0.0f,0.0f);
        }
        else if(newVC.y > -speed*jumpspeed)
        {
            newVC = new Vector2(0.0f,GetComponent<Rigidbody2D>().velocity.y-speed/100);
        }

        if (Input.GetKey(KeyCode.A))
        {
            newVC += new Vector2(-speed, 0.0f);//*Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            newVC += new Vector2(speed, 0.0f);//*Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W) && ground == true)
        {
            newVC += new Vector2(0.0f, speed*jumpspeed);//*Time.deltaTime;
            ground = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            newVC += new Vector2(0.0f, -speed);//*Time.deltaTime;
        }   
        GetComponent<Rigidbody2D>().velocity = newVC;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.contacts.Length > 0)
        {
            for(int i = 0; i < col.contacts.Length; i++)
            {
                ContactPoint2D contact = col.contacts[i];
                if(Vector3.Dot(contact.normal, Vector3.up) > 0.6)
                {
                    ground = true;
                }
            }
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if(col.contacts.Length > 0)
        {
            for(int i = 0; i < col.contacts.Length; i++)
            {
                ContactPoint2D contact = col.contacts[i];
                if(Vector3.Dot(contact.normal, Vector3.up) > 0.6)
                {
                    ground = true;
                }
            }
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        ground = false;
    }
}
