﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Talk : Interactable
{
    //public Dialogue dialogue;
    public override void Interact(){
        base.Interact();
        TriggerConversation();
        
    }
}
