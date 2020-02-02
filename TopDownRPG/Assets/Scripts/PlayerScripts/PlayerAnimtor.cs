using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimtor : MonoBehaviour
{
    const float locomationAnimationSmoothTime=.1f;
    NavMeshAgent agent;
    Animator animator;
    PlayerMotor motor;
    PlayerController player;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        motor=GetComponent<PlayerMotor>();
        agent=GetComponent<NavMeshAgent>();
        animator=GetComponent<Animator>();
        player=GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed=agent.velocity.magnitude/agent.speed;
        animator.SetFloat("speed",speed,locomationAnimationSmoothTime,Time.deltaTime);
    }
}
