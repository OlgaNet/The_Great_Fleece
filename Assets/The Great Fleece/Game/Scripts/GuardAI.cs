using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    public List<Transform> wayPoints;
    public Transform currentTarget;

    private NavMeshAgent _agent;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        if (wayPoints.Count > 0)
        {
            if (wayPoints[0] != null)
            {
                currentTarget = wayPoints[0];
                _agent.SetDestination(currentTarget.position);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTarget != null)
        {
            float distance = Vector3.Distance(transform.position, currentTarget.position);

            if (distance < 1.0f)
            {
                if (wayPoints[1] != null && currentTarget != wayPoints[1])
                {
                    currentTarget = wayPoints[1];
                    _agent.SetDestination(currentTarget.position);
                }
                else if (wayPoints[2] != null)
                {
                    currentTarget = wayPoints[2];
                    _agent.SetDestination(currentTarget.position);
                }
            }
        }

    }
}
