using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public Transform target;
    public Vector3 offset;

    public float pitch=2f;
    
    public float zoomSpeed=4.0f;
    public float maxZoom=15.0f;
    public float minZoom=2.0f;

    public float yawSpeed=100f;
    public float currentZoom=10.0f;
    public float currentYaw=0.0f;
    void Update(){
        currentZoom-=Input.GetAxis("Mouse ScrollWheel")*zoomSpeed;
        currentZoom=Mathf.Clamp(currentZoom,minZoom,maxZoom);
        currentYaw-=Input.GetAxis("Horizontal")*yawSpeed*Time.deltaTime;
    }
    void LateUpdate(){
        transform.position=target.position-offset*currentZoom;
        transform.LookAt(target.position+Vector3.up*pitch);
        transform.RotateAround(target.position,Vector3.up,currentYaw);
    }
}
