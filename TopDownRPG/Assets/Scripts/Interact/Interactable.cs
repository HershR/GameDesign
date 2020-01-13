﻿
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius =3f;
    bool isFocus=false;
    bool hasInteracted=false;
    Transform player;
    private DialogueManager ConverationTrig;
    public Transform interactionTransform;
    public Dialogue dialogue;
    public virtual void Interact()
    {
            //This method is meant to be overwritten
            Debug.Log("Interact");

    }
    void Update(){
        if(isFocus==true&&hasInteracted==false){
            float distance=Vector3.Distance(player.position,interactionTransform.position);
            if(distance<=radius){
                Interact();
                hasInteracted=true;
            }
        }
    }
    public void OnFocused(Transform playerTransform){
        isFocus=true;
        player=playerTransform;
        hasInteracted=false;
    }
    public void OnDefocused(){
        FindObjectOfType<DialogueManager>().EndDialogue();
        isFocus=false;
        player=null;
        hasInteracted=false;
    }

    public void TriggerConversation(){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
    public void FaceTarget(){
        Vector3 direction= (player.position-transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation=Quaternion.Slerp(transform.rotation,lookRotation,1.0f);
    }
    void OnDrawGizmosSelected(){
        if(interactionTransform==null)
            interactionTransform=transform;
        Gizmos.color=Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position,radius);
    }
}
