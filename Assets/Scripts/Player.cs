using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject door;
    public Camera MainCamera;
    float speed = 4;
    float jumpspeed = 175;
    bool ground = false;
    bool rpressed = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        Vector2 newVC = new Vector2(0.0f,rb.velocity.y);

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
            //newVC += new Vector2(0.0f, jumpspeed);//*Time.deltaTime;
            rb.AddForce(Vector3.up*jumpspeed);
            ground = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //newVC += new Vector2(0.0f, -speed);//*Time.deltaTime;
            rb.AddForce(Vector3.down);
        }   
        if (Input.GetKeyDown(KeyCode.R))
        {
            rpressed = true;
            GameObject tmp = Instantiate(gameObject,new Vector3(-1.0f,-0.5f,0.0f),Quaternion.identity);
            tmp.name = "Player";
            Destroy(gameObject);
        }

        rb.velocity = newVC;
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

    void OnBecameInvisible()
    {
        if(rpressed == false)
        {
            MainCamera.orthographicSize += 2;
            //MainCamera.transform.position += new Vector3(1.25f, 1.0f, 0.0f);;
            GameObject tmp = Instantiate(gameObject,new Vector3(-1.0f,-0.5f,0.0f),Quaternion.identity);
            tmp.name = "Player";
            Destroy(gameObject);
        }
    }
}
