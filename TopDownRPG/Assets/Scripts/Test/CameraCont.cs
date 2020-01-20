using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCont : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public bool useOffsetValue;
    public float rotateSpeed;
    public Transform piviot;
    private PlayerCont player;
    
    // Start is called before the first frame update
    void Start()
    {
        player= PlayerManager.instance.player.GetComponent<PlayerCont>();
        if(!useOffsetValue){
            offset=target.position-transform.position;
        }
        piviot.transform.position=target.transform.position;
        piviot.transform.parent=target.transform;
       // Cursor.lockstate=CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.focus==null){
        float horizontal = Input.GetAxis("Mouse X")*rotateSpeed;
        target.Rotate(0,horizontal,0);
        }
        float desiredYAngle =target.eulerAngles.y;
        Quaternion rotation=Quaternion.Euler(0,desiredYAngle,0);
        transform.position=target.position-(rotation*offset);
        transform.LookAt(target);
        
    }
}
