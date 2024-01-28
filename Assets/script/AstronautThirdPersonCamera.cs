using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cAstronautThirdPersonCamera : MonoBehaviour
{
    private const float Y_ANGLE_MIN = -90.0f;
    private const float Y_ANGLE_MAX = 90.0f;

    public Transform lookAt;
    public Transform camTransform;
    public float distance = 5.0f;
    public float heightOffset = 1.0f;
    
    private float currentX = 0.0f;
    private float currentY = 0f;
    bool TabOK = true;

    private void Start()
    {
        camTransform = transform;
        
    }

    private void Update()
    {      
        if(TabOK){

            currentX += Input.GetAxis("Mouse X");
            currentY -= Input.GetAxis("Mouse Y"); 

            currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        }
    }

    public void ChangeCameraFocus(Transform newFocus)
    {
        lookAt = newFocus;
    }

    private void LateUpdate()
    {
        if(TabOK){
            
            Vector3 dir = new Vector3(0, heightOffset, -distance);
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
            camTransform.position = lookAt.position + rotation * dir;
            camTransform.LookAt(lookAt.position + Vector3.up * heightOffset);
        }
    }
    public void invAtivo(bool tabOK){
        TabOK = tabOK;
    }
}
