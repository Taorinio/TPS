using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public int Health = 6;
    private NavMeshAgent _navMeshAgent;
    public List<Transform> patrolPoints;
    public float DamageSpeed = 2f; 
    public CharacterController player;
    private Transform randomSelected;
    private bool isPlayerNoticed;
    public float fieldOfView = 60f;
    public float minDetectDistance = 1f;
    private PlayerHealth PlayerH;
    bool isNear;
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        PlayerH = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        isNear = _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance;
        See();
        Patrol();
        IsAlive();
        Attack();
    }

    void Patrol()
    {
        if (!isPlayerNoticed)
        {
            if (randomSelected == null) randomSelected = patrolPoints[Random.Range(0, patrolPoints.Count)];
            if (isNear)
            {
                _navMeshAgent.destination = randomSelected.position;
            }
            else
            {
                randomSelected = null;
            }
        }
        else
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }
    
    void See()
    {
        var direction = player.transform.position - transform.position;
        var isNearEnemy = Vector3.Distance(transform.position, player.transform.position) < minDetectDistance;
        isPlayerNoticed = false;
        if (Vector3.Angle(transform.forward, direction) < fieldOfView || isNearEnemy)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject || isNearEnemy) // :)
                {
                    isPlayerNoticed = true;
                }
            }
        }
    }

    void IsAlive() {
        if (Health <= 0) {
            Destroy(gameObject);
        }
    }

    void Attack() {
        if (isNear && isPlayerNoticed) {
            PlayerH.DealDamage(DamageSpeed);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Hurt")) {
            Health -= 1;
        }
    }
}
