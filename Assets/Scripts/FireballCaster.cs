using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Fireball;
    public Transform target;
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            var TempFireball = Instantiate(Fireball, transform.position, Quaternion.identity);
            TempFireball.transform.LookAt(target.position);
        }
    }
}
