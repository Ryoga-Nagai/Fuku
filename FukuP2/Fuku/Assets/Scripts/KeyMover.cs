using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class KeyMover : MonoBehaviour
{
     public float speed = 1.0f;
 
    void Update()
    {
        if (Input.GetKey (KeyCode.I)) {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey (KeyCode.K)) {
            transform.position -= transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.L)) {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey (KeyCode.J)) {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey (KeyCode.U)) {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey (KeyCode.O)) {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        
    }
}