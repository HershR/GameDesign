﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour
{
    public float speed;
    private CharacterController controller;
    private Vector3 moveDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    { 
        moveDirection=new Vector3(Input.GetAxis("Horizontal")*speed,0.0f,Input.GetAxis("Vertical")*speed);
        moveDirection.y=(moveDirection.y+Physics.gravity.y);
        controller.Move(moveDirection * Time.deltaTime);
    
    }
}
