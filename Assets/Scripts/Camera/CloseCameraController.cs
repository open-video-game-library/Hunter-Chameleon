using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCameraController : MonoBehaviour{

  private GameObject camObj;
  Camera cam;

  void Start(){
    camObj = GameObject.Find("Foreground Camera");
    cam = camObj.GetComponent<Camera>();
  }

  void LateUpdate() {
    Vector3 _temp = cam.transform.position;
    _temp.x /= 4.0f;
    _temp.y = 40.0f;
    transform.position = _temp;
  }
}
