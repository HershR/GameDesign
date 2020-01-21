using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;
    Interactable interact;
    private Animator anime;
    void Start()
    {
        anime=this.gameObject.transform.GetChild(0).GetComponent<Animator>();
        agent=GetComponent<NavMeshAgent>();
    }
    void Update(){
        if(target!=null){
            agent.SetDestination(target.position);
            FaceTarget();
            if (Vector3.Distance(transform.position, agent.destination) <= interact.radius+0.2f)
            {
                anime.SetBool("moving",false);
            }
        }else{
            if (Vector3.Distance(transform.position, agent.destination) <= 0.50f)
            {
                anime.SetBool("moving",false);
            }
        }
    }
    // Update is called once per frame
    public void MoveToPoint(Vector3 point)
    {
        anime.SetBool("moving",true);
        agent.SetDestination(point);
        
    }
    public void FollowTarget(Interactable newTarget){
        anime.SetBool("moving",true);
        interact=newTarget;
        target=newTarget.interactionTransform;
        agent.stoppingDistance=newTarget.radius*0.8f;
        agent.updateRotation=false;
        
        //Debug.Log(newTarget.radius);
    }
    public void StopFollowingTarget(){
        //anime.SetBool("moving",false);
        agent.stoppingDistance=0.0f;
        agent.updateRotation=true;
        target=null;
        
    }
    void FaceTarget(){
        Vector3 direction=(target.position-transform.position).normalized;
        Quaternion lookRotation=Quaternion.LookRotation(new Vector3(direction.x,0f,direction.z));
        transform.rotation=Quaternion.Slerp(transform.rotation,lookRotation,1f);
    }
}
