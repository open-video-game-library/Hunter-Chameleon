using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleCameraController :  MonoBehaviour{

  private GameObject camObj;
  Camera cam;

  void Start(){
    camObj = GameObject.Find("Foreground Camera");
    cam = camObj.GetComponent<Camera>();
  }

  void LateUpdate() {
    Vector3 _temp = cam.transform.position;
    _temp.x /= 6.0f;
    _temp.y = 60.0f;
    transform.position = _temp;
  }
}
