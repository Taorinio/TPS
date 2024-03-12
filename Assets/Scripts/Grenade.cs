using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float Delay = 3;
    public GameObject explosionPrefab;

    void OnCollisionEnter(Collision other)
    {
        Invoke(nameof(Explode), Delay);
    }

    void Explode() {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
