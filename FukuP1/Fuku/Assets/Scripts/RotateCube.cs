using System;
using UnityEngine;
using System.Collections;

public class RotateCube : MonoBehaviour {
    float r = 0;

    void Update () {
         Transform myTransform = this.transform;
         
         Vector3 localAngle = myTransform.localEulerAngles;
         localAngle.x = r/2;
         localAngle.y = r/2;
         localAngle.z = r/2;
         myTransform.localEulerAngles = localAngle;
    r++;
    }
}
