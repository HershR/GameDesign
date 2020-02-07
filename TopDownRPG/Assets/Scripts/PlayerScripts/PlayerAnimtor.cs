using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimtor : MonoBehaviour
{
    const float locomationAnimationSmoothTime=.1f;
    NavMeshAgent agent;
    Animator animator;
    PlayerController player;
    private float time;
    string condition;
    // Start is called before the first frame update
    void Start()
    {
        agent=GetComponent<NavMeshAgent>();
        animator=GetComponent<Animator>();
        player=GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float speed=agent.velocity.magnitude/agent.speed;
        animator.SetFloat("speed",speed,locomationAnimationSmoothTime,Time.deltaTime);
        if(player.focus!=null){
            if(!string.IsNullOrEmpty(player.focus.animationCondition)){
                condition= player.focus.animationCondition;
                if(Vector3.Distance(player.transform.position,player.focus.transform.position)<=player.focus.radius){
                    animator.SetBool(condition,true);
                }
            }

        }else{
                animator.SetBool(condition,false);
                condition="";
            }
    }
}
