using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public int Health = 6;
    private NavMeshAgent _navMeshAgent;
    public List<Transform> patrolPoints;
    public CharacterController player;
    private Transform randomSelected;
    private bool isPlayerNoticed;
    public float fieldOfView = 60f;
    public float minDetectDistance = 1f;
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        See();
        Patrol();
        IsAlive();
    }

    void Patrol()
    {
        if (!isPlayerNoticed)
        {
            if (randomSelected == null) randomSelected = patrolPoints[Random.Range(0, patrolPoints.Count)];
            if (_navMeshAgent.gameObject.transform.position != new Vector3(randomSelected.position.x, _navMeshAgent.gameObject.transform.position.y, randomSelected.position.z))
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
        var isNear = Vector3.Distance(transform.position, player.transform.position) < minDetectDistance;
        isPlayerNoticed = false;
        if (Vector3.Angle(transform.forward, direction) < fieldOfView || isNear)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject || isNear) // :)
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

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Hurt")) {
            Health -= 1;
        }
    }
}
