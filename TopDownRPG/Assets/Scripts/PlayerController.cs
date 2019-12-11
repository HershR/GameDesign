using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour

{
    private float speed;
    private NavMeshAgent agent;
    private GameObject clickedObject;
    private DialogueTrigger ConverationTrig;
    private Interactable interactable;
    private bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        speed = 5.0f;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0)) {
            
            agent.stoppingDistance = 0;
            agent.isStopped = false;
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform.name=="Ground")
                {
                    FindObjectOfType<DialogueManager>().EndDialogue();
                    isActive = false;
                    agent.destination = hit.point;
                } else if (hit.transform.tag == "Interactable")
                {
                    isActive = true;
                    clickedObject = hit.transform.gameObject;
                    agent.stoppingDistance = 1.0f;
                    agent.destination = hit.point;
                }
            }
            
        }
        if (interactable == true && (Vector3.Distance(transform.position, clickedObject.transform.position) < 2.0f))
        {
            Interact();
        }
    }
    private void Interact() {

        ConverationTrig=  clickedObject.GetComponent<DialogueTrigger>();
        interactable=clickedObject.GetComponent<Interactable>();
        ConverationTrig.TriggerDialogue();
        isActive = false;
    }
}
