using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
    PlayerManager playerManager;
    CharacterStats myStats;
    EnemyController enemy;

    void Start(){
        playerManager=PlayerManager.instance;
        myStats=GetComponent<CharacterStats>();
        enemy=GetComponent<EnemyController>();
    }
    public override void Interact(){
        base.Interact();
        CharacterCombat playerCombat=playerManager.player.GetComponent<CharacterCombat>();
        if(playerCombat!=null){
            if(enemy.fov==enemy.angleToPlayer){
                playerCombat.SneakAttack(myStats);
            }else{
                playerCombat.Attack(myStats);
            }
        }
    }
}
