using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto : MonoBehaviour
{
    public float velocidad = 1;
    public float velRotacion = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vertical = Vector3.forward * EjeVertical();
        Vector3 horizontal = Vector3.up * Input.GetAxis("Mouse X");
        Vector3 derecha_izquierda = Vector3.right * EjeHorizontal();

        transform.Translate((vertical + derecha_izquierda) * velocidad * Time.deltaTime);
        transform.Rotate(horizontal * velRotacion * Time.deltaTime);
    }

    int EjeVertical()
    {
        int arriba = 0, abajo = 0;
        if (Input.GetKey(KeyCode.W))
        {
            arriba = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            abajo = 1;
        }

        return arriba - abajo;
    }

    int EjeHorizontal(){
        int derecha = 0, izquierda = 0;
        if (Input.GetKey(KeyCode.D))
        {
            derecha = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            izquierda = 1;
        }

        return derecha - izquierda;
    }
}
