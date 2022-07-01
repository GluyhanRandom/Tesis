using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following_Camera : MonoBehaviour
{
    public Transform Jugador;

    // Start is called before the first frame update
    void FixedUpdate() {
        transform.position = new Vector3(Jugador.position.x, Jugador.position.y, transform.position.z);
    }

}
