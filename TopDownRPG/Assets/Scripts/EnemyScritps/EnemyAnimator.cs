using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAnimator : MonoBehaviour
{
    const float locomationAnimationSmoothTime=.1f;
    NavMeshAgent agent;
    Animator animator;
    EnemyController player;
    private float time;
    void Start()
    {
        agent=GetComponent<NavMeshAgent>();
        animator=GetComponent<Animator>();
        player=GetComponent<EnemyController>();
    }
    

    // Update is called once per frame
    void Update()
    {
        float speed=agent.velocity.magnitude/agent.speed;
        animator.SetFloat("speed",speed,locomationAnimationSmoothTime,Time.deltaTime);
    }
}
