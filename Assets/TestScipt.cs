using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScipt : MonoBehaviour
{
    public static int A =5;
    private int B;
    private int C =10;
    private Transform flyTransform;
    // Start is called before the first frame update
    void Start()
    {
        flyTransform = this.GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        B = C;
        Debug.Log(B);
    }
}
