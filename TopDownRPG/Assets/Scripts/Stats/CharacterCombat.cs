﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed=1.0f;
    private float attackCoolDown=0.0f;
    public float attackDelay=0.6f;
    public event System.Action OnAttack;
    CharacterStats myStats;
    
    void Start(){
        myStats=GetComponent<CharacterStats>();
    }
    
    void Update(){

        attackCoolDown-=Time.deltaTime;
    }
    
    public void Attack(CharacterStats targetStats){
        if(attackCoolDown<=0.0f)
        {
            StartCoroutine(DoDamage(targetStats,attackDelay));  
            if(OnAttack!=null){
                OnAttack();
            }
            attackCoolDown=1.0f/attackSpeed;
        }
    }
    IEnumerator DoDamage(CharacterStats stats,float delay){
        yield return new WaitForSeconds(delay);

        stats.TakeDamage(myStats.damage.GetValue());
    }
}