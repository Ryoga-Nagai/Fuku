using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraReset : MonoBehaviour
{

    public GameObject LeftCamera;
    public GameObject RightCamera;

            private Vector3 OriginPositionR;
        private Vector3 OriginPositionL;
        private Quaternion OriginRotationR;
        private Quaternion OriginRotationL;

    void start(){
        OriginPositionL = LeftCamera.transform.position;
        OriginPositionR = RightCamera.transform.position;
        OriginRotationL = LeftCamera.transform.rotation;
        OriginRotationR = RightCamera.transform.rotation;
    }

      public void OnClickResetButton()
      {
        LeftCamera.transform.position = OriginPositionL;
        LeftCamera.transform.rotation = OriginRotationL;
        RightCamera.transform.position = OriginPositionR;
        RightCamera.transform.rotation = OriginRotationR;
    }
}
