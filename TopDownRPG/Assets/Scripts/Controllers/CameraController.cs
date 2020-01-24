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
    public float defaultZoom=10.0f;
    
    
    void Update(){
        currentZoom-=Input.GetAxis("Mouse ScrollWheel")*zoomSpeed;
        currentZoom=Mathf.Clamp(currentZoom,minZoom,maxZoom);
        if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.A)) { 
            currentYaw -=Input.GetAxis("Horizontal")*yawSpeed*Time.deltaTime;
        }
        Reposition();
        
        
    }
    void LateUpdate(){
        transform.position=target.position-offset*currentZoom;
        transform.LookAt(target.position+Vector3.up*pitch);
        transform.RotateAround(target.position,Vector3.up,currentYaw);
    }
    void Reposition(){
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,Mathf.Infinity)){
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10.0f, Color.white);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * 2.0f, Color.white);
            if(hit.collider.tag!="Player"){
                currentZoom=currentZoom-0.50f;
                Debug.Log("ZoomOut");
            }else if(hit.collider.tag=="Player"){
                Debug.Log("Player Hit");
                if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.back),out hit,2.0f)){
                    //If not null
                    Debug.Log("BackRay:hit");
                }else{
                    //if null
                    currentZoom=currentZoom+0.02f;
                    Debug.Log("BackRay:null");
                }              
            }
        }
        
    }
}
