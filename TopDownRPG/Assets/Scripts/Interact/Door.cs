using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public Item key;
    //public Dialogue dialogue;
    public override void Interact(){
        base.Interact();
        if(key!=null){
            if((Inventory.instance.items).Contains(key)){
                Open();
            }else{
                TriggerConversation();
            }
        }else
        {
            Open();
        }
        
    }
    void Open(){
        Destroy(gameObject);
        Inventory.instance.Remove(key);
    }
}
