using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius=10f;
    public float fov=45f;
    private float angleToPlayer;
    Transform target;
    NavMeshAgent agent;
    bool IsChasing =false;
    // Start is called before the first frame update
    void Start()
    {
        target=PlayerManager.instance.player.transform;
        agent=GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance= Vector3.Distance(target.position,transform.position);
        angleToPlayer=Vector3.Angle(target.position-transform.position,transform.forward);
        if(distance<=lookRadius&&angleToPlayer<=fov){
            agent.SetDestination(target.position);
            FaceTarget();
            IsChasing=true;
        }else{
            agent.isStopped=true;
            agent.ResetPath();
        }
        if(IsChasing==true){
                lookRadius=5.0f;
            }else{
                lookRadius=2.0f;
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
