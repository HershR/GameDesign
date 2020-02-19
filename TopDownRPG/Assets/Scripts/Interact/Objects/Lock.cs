using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : Interactable
{
    public Item key;
    public bool isOpen;
    public override void Interact(){
        base.Interact();
        if(key!=null){
            if((Inventory.instance.items).Contains(key)){
                isOpen=true;
            }else{
                TriggerConversation();
            }
        }else
        {
            isOpen=true;
            Debug.Log("Door open");
        }
        
    }
}
