using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public Item key;
    //public Dialogue dialogue;
    public override void Interact(){
        base.Interact();
        if((Inventory.instance.items).Contains(key)){
            Open();
        }
        
    }
    void Open(){
        Destroy(gameObject);
        Inventory.instance.Remove(key);
    }
}
