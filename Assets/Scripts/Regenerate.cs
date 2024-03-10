using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regenerate : MonoBehaviour
{
    PlayerHealth Player;
    public float Strength = 25;

    void Start()
    {
        Player = GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Heal")) {
            Player.Heal(Strength);
            Destroy(other.gameObject);
        }
    }
}
