using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius=10f;
    public float fov=45f;
    public float angleToPlayer;

    Transform target;
    NavMeshAgent agent;
    CharacterCombat combat;
    EnemyStats stats;
    float health;
    float distance;
    // Start is called before the first frame update
     void Start()
    {
        target=PlayerManager.instance.player.transform;
        agent=GetComponent<NavMeshAgent>();
        combat=GetComponent<CharacterCombat>();
        stats=GetComponent<EnemyStats>();
        health=stats.currentHealth;
        
    }

    // Update is called once per frame
     void Update()
    {
         distance= Vector3.Distance(target.position,transform.position)*0.7f;
        if(InFieldOfView()){
            agent.SetDestination(target.position);
            FaceTarget();
            if(distance<=agent.stoppingDistance){
               CharacterStats targetStats= target.GetComponent<CharacterStats>();
               if(targetStats!=null&&stats.currentHealth>0){
                    combat.Attack(targetStats);
                }
            }
        }
        if(health>stats.currentHealth&&stats.currentHealth>0){
            FaceTarget();
            health=stats.currentHealth;
        }
    }
    public bool InFieldOfView(){
        
        angleToPlayer=Vector3.Angle(target.position-transform.position,transform.forward);
        return (distance<=lookRadius&&angleToPlayer<=fov);
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
