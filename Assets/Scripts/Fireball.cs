using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float Speed = 1f;
    public float Lifetime = 5f;

    void Start()
    {
        Invoke("DestroyObject", Lifetime);
    }

    void FixedUpdate()
    {
        TranslateObject(); 
    }

    void OnCollisionEnter(Collision other)
    {
        DestroyObject();
    }

    void TranslateObject() {
        transform.position += transform.forward * Time.fixedDeltaTime * Speed;
    }

    void DestroyObject() {
        Destroy(transform.parent.gameObject);
    }
}
