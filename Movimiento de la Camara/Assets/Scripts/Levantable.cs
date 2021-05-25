using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levantable : MonoBehaviour
{
    public int Escena;
    public bool Impacto = false;
    public float Deteccion = 0.5f;
    //public GameObject zona;
    public GameObject objeto;
    //public Transform posicion;
    public Vector3 puntoAgarre;
    // Start is called before the first frame update

    // https://us.bbcollab.com/guest/00ee6a3224bf46d5bc3013b446153d55 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Impacto == false && transform.childCount >= 1){
            GetComponentInChildren<Rigidbody>().useGravity = true;
            GetComponentInChildren<Rigidbody>().isKinematic = false;
            GetComponentInChildren<Rigidbody>().freezeRotation = false;
            GetComponentInChildren<Transform>().SetParent(null);
        }
        RaycastHit cuboX;
        bool Agarre = Physics.Raycast(transform.position, transform.forward, out cuboX, Deteccion);

        puntoAgarre = transform.position + (transform.forward * Deteccion);

       // zona.transform.position = puntoAgarre;

        if (Agarre == true){
            if (cuboX.transform.tag != "Zona"){
                //Debug.Log("Golpe");
            }
            /*Debug.Log(cuboX.transform.name);
            Impacto = true;
            objeto = cuboX.collider.gameObject;*/
            
        }
        /*else{
            Impacto = false;
            objeto = null;
        }*/

        /*if(Impacto == true && Input.GetMouseButton(0) == true){
            Debug.Log("Golpe");
            if (objeto.CompareTag("Suelo")){
                Debug.Log("Si me destruyes, caes al vacio");
                
            }
            else if (objeto.CompareTag("Next")){
                SceneManager.LoadScene(Escena);
            }
            else{
                objeto.GetComponent<Rigidbody>().isKinematic = true;
                objeto.transform.position = puntoAgarre;
            }  
        }
        else{
            objeto.GetComponent<Rigidbody>().isKinematic = false;
        }*/
        
    }
    
    void OnTriggerEnter(Collider other){
        /*if (objeto == null){
            Debug.Log(other.transform.name);
            Impacto = true;
            objeto = other.gameObject;
        }*/
    }

    void OnTriggerStay(Collider other){
        Debug.Log(other.transform.name);
        if (objeto == null)
        {
            //Debug.Log(other.transform.name);
            Impacto = true;
            objeto = other.gameObject;
        }
        //Debug.Log("estoy en contacto");
        if (Impacto == true && Input.GetMouseButton(0) == true){
            //Debug.Log("Golpe");
            if (other.CompareTag("Suelo")){

                //Debug.Log("Si me destruyes, caes al vacio");
            }
            else if (other.CompareTag("Next")){
                SceneManager.LoadScene(Escena);
            }
            else{
                other.transform.SetParent(transform);
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.GetComponent<Rigidbody>().freezeRotation = true;
                //objeto.transform.position = puntoAgarre;
                
            }
        }
        else if (other.CompareTag("Suelo") != true){
            other.GetComponent<Rigidbody>().useGravity = true;
            other.GetComponent<Rigidbody>().isKinematic = false;
            other.GetComponent<Rigidbody>().freezeRotation = false;
            other.transform.SetParent(null);

        }
    }
    

    void OnTriggerExit(Collider other){
        if (other.transform.name == objeto.transform.name){
            //Debug.Log(other.transform.name);
            Impacto = false;
            objeto = null;
        }
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward * Deteccion);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(puntoAgarre, 0.2f);
        if (Impacto == true){
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(objeto.transform.position, 0.3f);
        }
    }
}
