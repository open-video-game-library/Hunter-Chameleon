using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChameleonCollider : MonoBehaviour{
    private void LateUpdate(){
      Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);
      Vector2 max = Camera.main.ViewportToWorldPoint(Vector2.one);
      transform.position = new Vector3((max.x + min.x) / 2.0f, -5.0f, 1.0f);
    }
}
