﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CharacterAnimator : MonoBehaviour
{
    public AnimationClip replaceableAttackAnim;
    public AnimationClip[] defaultAttackAnimSet;
    protected AnimationClip[] currentAttackAnimSet;
    const float locomationAnimationSmoothTime=.1f;
    NavMeshAgent agent;
    protected Animator animator;
    protected CharacterCombat combat;
    public AnimatorOverrideController overrideController;

    protected virtual void Start()
    {
        agent=GetComponent<NavMeshAgent>();
        animator=GetComponentInChildren<Animator>();
        combat=GetComponent<CharacterCombat>();
        if(overrideController==null){
            overrideController= new AnimatorOverrideController(animator.runtimeAnimatorController);
        }
        animator.runtimeAnimatorController=overrideController;

        currentAttackAnimSet=defaultAttackAnimSet;
        combat.OnAttack+=OnAttack;
        combat.OnSneakAttack+=SneakAttack;
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        float speed=agent.velocity.magnitude/agent.speed;
        animator.SetFloat("speed",speed,locomationAnimationSmoothTime,Time.deltaTime);
        animator.SetBool("InCombat",combat.InCombat);
    }
    protected virtual void OnAttack(){
        animator.SetTrigger("attack");
        int attackIndex=Random.Range(0,currentAttackAnimSet.Length);
        overrideController[replaceableAttackAnim.name]=currentAttackAnimSet[attackIndex];
    }
    protected virtual void SneakAttack()
    {
        animator.SetTrigger("sneakAttack");
    }
}