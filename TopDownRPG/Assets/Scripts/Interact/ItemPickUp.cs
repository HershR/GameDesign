﻿using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item item;
    public override void Interact(){
        base.Interact();
        
        PickUp();

        
    }
    void PickUp(){
        Debug.Log("Picking up "+item.name);
        bool wasPickedUp= Inventory.instance.Add(item);

        if(wasPickedUp==true){
            
            item.TriggerDialogue();
            playerAnime.SetTrigger("itemPickup");
            Destroy(gameObject,1.0f);
        }
    }
}
