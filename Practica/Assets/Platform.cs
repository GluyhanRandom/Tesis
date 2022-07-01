using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    float speed = 3;
    public bool movingUp = true;
    public bool movingRight = true;
    int platformLayer;

    private void Start()
    {
        platformLayer = gameObject.layer;
    }

    void Update()
    {
        if (platformLayer == 21) {
            if (movingUp == true) {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.down * speed * Time.deltaTime);
            }
        } else if (platformLayer == 22)
        {
            if (movingRight == true)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            if (platformLayer == 21) {
                if (movingUp == true)
                {
                    movingUp = false;
                }
                else
                {
                    movingUp = true;
                }
            } else if (platformLayer == 22)
            {
                if (movingRight == true)
                {
                    movingRight = false;
                }
                else
                {
                    movingRight = true;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.layer == 9)
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
