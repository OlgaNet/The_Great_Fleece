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
    private int _currentTarget;
    private bool _reverse;
    private bool _targetReached;
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        //_agent.SetDestination(wayPoints[_currentTarget].position); //error:"ArgumentOutOfRangeException: Index was out of range. Must be non-negative and less than the size of the collection. Parameter name: index"
        // Check if there are any waypoints before setting the destination //fixed
        if (wayPoints.Count > 0)
        {
            _agent.SetDestination(wayPoints[_currentTarget].position);
        }
        else
        {
            Debug.LogWarning("No waypoints assigned for GuardAI!");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (wayPoints.Count > 0 && wayPoints[_currentTarget] != null)
        {
            _agent.SetDestination(wayPoints[_currentTarget].position);
            

            float distance = Vector3.Distance(transform.position, wayPoints[_currentTarget].position);

            if (distance < 1 && (_currentTarget == 0 || _currentTarget == wayPoints.Count - 1))
            {
                _anim.SetBool("Walk", false);
            }
            else
            {
                _anim.SetBool("Walk", true);
            }

            if (distance < 1.0f && _targetReached == false)
            {
                if (wayPoints.Count < 2)
                {
                    return;
                }

                if ((_currentTarget == 0 || _currentTarget == wayPoints.Count - 1) && wayPoints.Count > 1)
                {
                    _targetReached = true;
                    Debug.Log("Target Reached: " + _targetReached);
                    StartCoroutine(WaitBeforeMoving());
                }
                else
                {
                    if (_reverse == true)
                    {
                        _currentTarget--;
                        if (_currentTarget <= 0)
                        {
                            _reverse = false;
                            _currentTarget = 0;
                        }
                    }
                    else
                    {
                        _currentTarget++;
                    }
                }
            }
        }

    }
    IEnumerator WaitBeforeMoving()
    {
        Debug.Log("WaitBeforeMoving()");

        if (_currentTarget == 0)
        {
            //at beginning
            yield return new WaitForSeconds(2.0f);
        }
        else if (_currentTarget == wayPoints.Count - 1)
        {
            //at end
            yield return new WaitForSeconds(2.0f);
        }

        if (_reverse == true)
        {
            _currentTarget--;

            if (_currentTarget == 0)
            {
                _reverse = false;
                _currentTarget = 0;
            }
        }
        else if (_reverse == false)
        {
            _currentTarget++;

            if (_currentTarget == wayPoints.Count)
            {
                //you've made it to the end
                _reverse = true;
                _currentTarget--;
            }
        }

        _targetReached = false;
    }
}
