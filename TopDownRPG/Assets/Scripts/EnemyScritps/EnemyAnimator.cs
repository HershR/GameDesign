using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAnimator : CharacterAnimator
{
    EnemyController player;
    void Start()
    {
        
        player=GetComponent<EnemyController>();
    }
    

    // Update is called once per frame
    void Update()
    {
    
    }
}
