using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimator : MonoBehaviour
{
    public AnimatorOverrideController overrideController;
    protected Animator animator;
    protected virtual void Start()
    {
        animator=GetComponentInChildren<Animator>();
        if(overrideController==null){
            overrideController= new AnimatorOverrideController(animator.runtimeAnimatorController);
        }
        animator.runtimeAnimatorController=overrideController;

        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
