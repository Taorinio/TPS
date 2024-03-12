using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float Damage = 50f;
    public float MaxSize = 5f;
    public float Speed = 5f;
    void Start()
    {
        transform.localScale = Vector3.zero;
    }

    void Update()
    {
        if (transform.localScale.magnitude < (Vector3.one * MaxSize).magnitude) { transform.localScale += Vector3.one * Time.deltaTime * Speed;}
        else { Destroy(gameObject); }
    }

    void OnTriggerEnter(Collider other)
    {
        var PlayerH = other.GetComponent<PlayerHealth>();
        if (PlayerH != null) PlayerH.DealDamage(Damage);
        var EnemyH = other.GetComponent<EnemyAI>();
        if (EnemyH != null) EnemyH.DealDamage(Damage);
    }
}
