using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Fireball;
    public Transform target;
    public Camera PlayerCamera;
    public float Distance;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        var ray = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.7f, 0));

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            target.position = hit.point;
        }
        else {
            target.position = ray.GetPoint(Distance);
        }

        if (Input.GetMouseButtonDown(0)) {
            var TempFireball = Instantiate(Fireball, transform.position, Quaternion.identity);
            TempFireball.transform.LookAt(target.position);
        }
    }
}
