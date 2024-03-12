using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    public GameObject Grenade;
    public float Force;
    void Update()
    {
        ThrowUpdate(); 
    }
    void ThrowUpdate() {
        if (Input.GetMouseButtonDown(1)) {
            var GrenadeObject = Instantiate(Grenade, transform.position, Quaternion.identity);
            GrenadeObject.GetComponent<Rigidbody>().AddForce(transform.forward * Force);
        }
    }
}
