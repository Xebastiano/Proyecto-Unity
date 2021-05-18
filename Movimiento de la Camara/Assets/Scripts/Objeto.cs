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

        transform.Translate(vertical * velocidad * Time.deltaTime);
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
}
