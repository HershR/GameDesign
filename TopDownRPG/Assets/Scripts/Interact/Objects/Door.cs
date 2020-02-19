using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    
    private Animator animator;
    private Lock lockScript;

    void Start(){
        animator=GetComponentInChildren<Animator>();
        lockScript=GetComponentInChildren<Lock>();
    }
    //public Dialogue dialogue;
    public override void Interact(){
        base.Interact();
        animator.SetBool("IsUnlocked",lockScript.isOpen);
        
    }
}
