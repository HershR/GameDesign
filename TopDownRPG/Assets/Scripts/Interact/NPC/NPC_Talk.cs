using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Talk : Interactable
{
    public override void Interact(){
        base.Interact();
        Debug.Log("Player has interacted");
        FaceTarget();
        TriggerConversation();   
    }
}
