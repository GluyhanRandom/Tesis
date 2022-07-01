using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{ 
    public float speed = 10f;
    public Rigidbody2D rigidBody;
    LayerMask playerLayerMask = 9;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == playerLayerMask)
        {
            Destroy(gameObject);
        } else if (collision.gameObject.layer == 16)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        rigidBody.velocity = transform.right * speed;
    }
}