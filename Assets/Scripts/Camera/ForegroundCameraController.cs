using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForegroundCameraController : MonoBehaviour
{
    //private float rate = 0.05f;

    [SerializeField]
    private GameObject cirsorAim;

    void Start()
    {
    }

    void LateUpdate()
    {
        // Vector3 temp = transform.position;
        // temp.x += Input.GetAxis("Horizontal") * rate;
        // temp.x = Mathf.Clamp(temp.x, -2, 2);

        // Vector3 temp = transform.position;
        // temp.x = -(cirsorAim.transform.position.x * rate);

        // transform.position = temp;
    }
}
