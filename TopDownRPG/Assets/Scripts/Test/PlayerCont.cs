using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour
{
    public float speed;
    private CharacterController controller;
    private Vector3 moveDirection;
    public LayerMask InteractMask;
    public Transform origin;
    public Interactable focus;
    public float Range;
    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        //Range=2.0f;

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(origin.transform.position,transform.TransformDirection(Vector3.forward),out hit,Range,InteractMask)){
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
            Interactable interactable=hit.collider.GetComponent<Interactable>();
                if(interactable!=null){
                    if(Input.GetKeyDown(interactable.InteractKey)){
                        SetFocus(interactable);
                        Debug.Log("Did player press key: "+Input.GetKeyDown(interactable.InteractKey));
                    }
                }
        }else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * Range, Color.white);
            //Debug.Log("Did not Hit");
        }
        
            if(focus==null){
                //if (Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.DownArrow)) {     
                    moveDirection = (transform.forward*Input.GetAxis("Vertical"))+(transform.right*Input.GetAxis("Horizontal"));
                    moveDirection=moveDirection.normalized*speed;
                    moveDirection.y = (moveDirection.y + Physics.gravity.y);
                    controller.Move(moveDirection * Time.deltaTime); 
                //}
            }else if(focus.hasInteracted==true){
                RemoveFoucs();
            }
    }
    void SetFocus(Interactable newFocus){
        if(newFocus!=focus){
            if(focus!=null)
                focus.OnDefocused();
            focus=newFocus;
        }
        newFocus.OnFocused(transform);         
    }
    void RemoveFoucs(){
        FindObjectOfType<DialogueManager>().EndDialogue();
        if(focus!=null)
        focus.OnDefocused();
        focus=null;
    }
}
