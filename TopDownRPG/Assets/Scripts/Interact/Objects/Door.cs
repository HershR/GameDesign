using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public bool IsLocked=true;
    public Item key;

    void Start(){
        IsLocked=true;
    }
    //public Dialogue dialogue;
    public override void Interact(){
        base.Interact();
        CheckKey();
        
    }
    private void CheckKey(){
        if(key!=null){
            if((Inventory.instance.items).Contains(key)){
                IsLocked=false;
                key=null;
                Debug.Log("UnLocked");
            }else{
                IsLocked=true;
                TriggerConversation();
            }
        }else{
            IsLocked=false;
            Debug.Log("NoKey");
        }
    }

}
