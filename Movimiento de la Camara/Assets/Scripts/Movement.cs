using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour{

    public float velocidad = 1;
    public float velRotacion = 1;

   // public Quaternion quieto;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
       // Vector3 horizontal = Vector3.up * Input.GetAxis("Mouse X");
       // Vector3 vertical = Vector3.forward * EjeVertical();
        Vector3 rotVer = Vector3.left * Input.GetAxis("Mouse Y");

       // transform.Translate(vertical * velocidad * Time.deltaTime);
       // transform.Rotate(horizontal * velRotacion * Time.deltaTime);
        transform.Rotate(rotVer * velRotacion * Time.deltaTime);
       // quieto = GetComponent<Transform>().rotation;
        //quieto.z = 0;
        //transform.rotation = quieto;
    }

    int EjeVertical(){
        int arriba = 0, abajo = 0;
        if (Input.GetKey(KeyCode.W)){
            arriba = 1;
        }
        if (Input.GetKey(KeyCode.S)){
            abajo = 1;
        }

        return arriba - abajo;
    }
}
