﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;
    
    void Start()
    {
        agent=GetComponent<NavMeshAgent>();
    }
    void Update(){
        if(target!=null){
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }
    // Update is called once per frame
    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }
    public void FollowTarget(Interactable newTarget){
        
        target=newTarget.interactionTransform;
        agent.stoppingDistance=newTarget.radius;
        agent.updateRotation=false;
        //Debug.Log(newTarget.radius);
    }
    public void StopFollowingTarget(){
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
