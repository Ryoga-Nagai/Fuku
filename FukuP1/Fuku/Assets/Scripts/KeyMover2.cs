using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class KeyMover2 : MonoBehaviour
{
     public float speed = 1.0f;
 
    void Update()
    {
        if (Input.GetKey (KeyCode.W)) {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey (KeyCode.S)) {
            transform.position -= transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey (KeyCode.A)) {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey (KeyCode.Q)) {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey (KeyCode.E)) {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        
    }
}