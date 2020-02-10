using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimator : CharacterAnimator
{
    PlayerController player;
    string condition;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        player=GetComponent<PlayerController>();
    }

    // Update is called once per frame
     void  Update()
    {
        base.Update();
    }
}
