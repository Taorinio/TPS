using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float RotationSpeed = 1f;
    public Transform Camera;
    public float Min;
    public float Max;
    float newAngleX;
    float newAngleY;
    void Update()
    {
        newAngleY = transform.localEulerAngles.y + Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse X");
        transform.localEulerAngles = new Vector3(0, newAngleY, 0);
        newAngleX = Camera.localEulerAngles.x - Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse Y");
        if (newAngleX > 180) newAngleX -= 360;
        Camera.localEulerAngles = new Vector3(Mathf.Clamp(newAngleX, Min, Max), 0, 0);
    }
}
