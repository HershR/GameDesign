using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerMotor motor;
    Camera cam;

    public Interactable focus;
    public LayerMask movementMask;
    
    void Start()
    {  
        motor=GetComponent<PlayerMotor>();
        cam=Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(EventSystem.current.IsPointerOverGameObject())
            return;
        if(Input.GetMouseButtonDown(0)){
            Ray ray=cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit,100,movementMask)){
                
                motor.MoveToPoint(hit.point);
                RemoveFoucs();
            }
        }

        if(Input.GetMouseButtonDown(1)){
            Ray ray=cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit,100)){
                Interactable interactable=hit.collider.GetComponent<Interactable>();
                if(interactable!=null){
                    SetFocus(interactable);
                }
            }
        }
    }
    void SetFocus(Interactable newFocus){
            if(newFocus!=focus){
                if(focus!=null)
                    focus.OnDefocused();
                focus=newFocus;
                motor.FollowTarget(newFocus);
            }
            
            newFocus.OnFocused(transform);
            
    }
    void RemoveFoucs(){
        FindObjectOfType<DialogueManager>().EndDialogue();
        if(focus!=null)
        focus.OnDefocused();
        focus=null;
        motor.StopFollowingTarget();
    }
}
