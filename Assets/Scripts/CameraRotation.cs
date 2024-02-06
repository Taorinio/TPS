using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    public float RotationSpeed = 1f;
    public float MinAngle;
    public float MaxAngle;
    public Transform CameraAxis;

    void Update()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse X"), 0);
        
        float ValueX = CameraAxis.localEulerAngles.x - Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse Y");


        CameraAxis.localEulerAngles = new Vector3(ValueX, 0, 0);
    }
}
