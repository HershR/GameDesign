using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : CharacterAnimator
{
    public float lookRadius=10f;
    public float fov=45f;
    private float angleToPlayer;

    Transform target;
    NavMeshAgent agent;
    CharacterCombat combat;
    // Start is called before the first frame update
     void Start()
    {
        base.Start();
        target=PlayerManager.instance.player.transform;
        agent=GetComponent<NavMeshAgent>();
        combat=GetComponent<CharacterCombat>();
        
    }

    // Update is called once per frame
     void Update()
    {
        base.Update();
        float distance= Vector3.Distance(target.position,transform.position);
        angleToPlayer=Vector3.Angle(target.position-transform.position,transform.forward);
        if(distance<=lookRadius&&angleToPlayer<=fov){
            agent.SetDestination(target.position);
            FaceTarget();
            if(distance<=agent.stoppingDistance){
               CharacterStats targetStats= target.GetComponent<CharacterStats>();
               if(targetStats!=null){
                    combat.Attack(targetStats);
                }
            }
        }else{
            agent.isStopped=true;
            agent.ResetPath();
        }
    }
    void FaceTarget(){
        Vector3 direction= (target.position-transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation=Quaternion.Slerp(transform.rotation,lookRotation,1f);
    }
    void OnDrawGizmosSelected(){
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(transform.position,lookRadius);
    }
}
