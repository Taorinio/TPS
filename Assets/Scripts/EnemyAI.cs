using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    public List<Transform> patrolPoints;
    public CharacterController player;
    private Transform randomSelected;
    private bool isPlayerNoticed;
    public float fieldOfView = 60f;
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Raysee();
        Patrol();
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
    
    void Raysee()
    {
        var direction = player.transform.position - transform.position;
        isPlayerNoticed = false;
        if (Vector3.Angle(transform.forward, direction) < fieldOfView)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    isPlayerNoticed = true;
                }
            }
        }
    }
}
