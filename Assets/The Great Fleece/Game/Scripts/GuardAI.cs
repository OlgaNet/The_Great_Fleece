using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    public List<Transform> wayPoints;
    private NavMeshAgent _agent;
    [SerializeField]
    private int currentTarget;
    private bool reverse;
    private bool _targetReached;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        //_agent.SetDestination(wayPoints[currentTarget].position); //error:"ArgumentOutOfRangeException: Index was out of range. Must be non-negative and less than the size of the collection. Parameter name: index"
        // Check if there are any waypoints before setting the destination //fixed
        if (wayPoints.Count > 0)
        {
            _agent.SetDestination(wayPoints[currentTarget].position);
        }
        else
        {
            Debug.LogWarning("No waypoints assigned for GuardAI!");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (wayPoints.Count > 0 && wayPoints[currentTarget] != null)
        {
            _agent.SetDestination(wayPoints[currentTarget].position);

            float distance = Vector3.Distance(transform.position, wayPoints[currentTarget].position);

            if (distance < 1.0f && _targetReached == false)
            {
                _targetReached = true;
                Debug.Log("Target Reached: " + _targetReached);

                StartCoroutine(WaitBeforeMoving());

            }
        }

    }
    IEnumerator WaitBeforeMoving()
    {
        Debug.Log("WaitBeforeMoving()");
        yield return new WaitForSeconds(2.0f);

        if (reverse == true)
        {
            currentTarget--;

            if (currentTarget == 0)
            {
                reverse = false;
                currentTarget = 0;
            }
        }
        else if (reverse == false)
        {
            currentTarget++;

            if (currentTarget == wayPoints.Count)
            {
                //you've made it to the end
                reverse = true;
                currentTarget--;
            }
        }

        _targetReached = false;
    }
}
