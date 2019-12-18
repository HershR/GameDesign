using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Open : Interactable
{
    Item key;
    

    public override void Interact(){
        base.Interact();
       
    }
    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag=="Player"){

        }
    }
}
