using System.Collections;
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
        controller = gameObject.GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = (transform.forward*Input.GetAxis("Vertical"))+(transform.right*Input.GetAxis("Horizontal"));
        moveDirection=moveDirection.normalized*speed;
        moveDirection.y = (moveDirection.y + Physics.gravity.y);
        controller.Move(moveDirection * Time.deltaTime);
    }
}
