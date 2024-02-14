using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    public List<Transform> patrolPoints;
    private Transform randomSelected;
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (randomSelected == null) randomSelected = patrolPoints[Random.Range(0, patrolPoints.Count)];
        if (_navMeshAgent.gameObject.transform.position != new Vector3(randomSelected.position.x, _navMeshAgent.gameObject.transform.position.y, randomSelected.position.z)) {
            _navMeshAgent.destination = randomSelected.position;
        }
        else {
            randomSelected = null;
        }
    }
}
