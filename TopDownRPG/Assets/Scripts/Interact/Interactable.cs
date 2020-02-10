using TMPro;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius =3f;
    bool isFocus=false;
    public bool hasInteracted=false;
    Transform player;
    private DialogueManager dialogueManager;
    public Transform interactionTransform;
    public Dialogue dialogue;
    [HideInInspector]
    protected Animator playerAnime;
   
   public virtual void Interact()
    {
        //Debug.Log("Interact");
    }
    void Start(){
        dialogueManager=FindObjectOfType<DialogueManager>();
        playerAnime=PlayerManager.instance.player.GetComponentInChildren<Animator>();;
    }
    void Update(){
        if(isFocus==true&&hasInteracted==false){
            float distance=Vector3.Distance(player.position,interactionTransform.position);
            if(distance<=radius){
                //TriggerConversation();
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
        dialogueManager.StartDialogue(dialogue);
    }
    public void FaceTarget(){
        Vector3 direction= (player.position-transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation=Quaternion.Slerp(transform.rotation,lookRotation,1.0f);
    }
    public float heightDifference(){
        return player.position.y-interactionTransform.position.y;
    }
    void OnDrawGizmosSelected(){
        if(interactionTransform==null)
            interactionTransform=transform;
        Gizmos.color=Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position,radius);
    }
}
