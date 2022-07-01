using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float newX = Mathf.Clamp(transform.position.x, 10, -10);
        float newY = Mathf.Clamp(transform.position.y, 10, -10);
        transform.position = new Vector3(newX, newY, transform.position.z);
    }
}
