using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomach : MonoBehaviour{
    void Start(){
    }

    void Update(){
    }

    private void OnTriggerEnter2D( Collider2D collision ){
        if ( collision.name.Contains( "Fly" ) ){
            Destroy( collision.gameObject );
        }
    }
}
