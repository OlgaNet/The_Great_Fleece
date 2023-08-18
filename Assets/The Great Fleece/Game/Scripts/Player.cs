using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _anim; //Get handle to animator
    private Vector3 _target;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if left click
        if (Input.GetMouseButtonDown(0))
        {
            //cast a ray from mouse position
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                //debug the floor position hit
                //Debug.Log("Hit:" + hitInfo.point);

                _agent.SetDestination(hitInfo.point);
                _anim.SetBool("Walk", true);
                _target = hitInfo.point; //can use outside

                //----create object at floor position
                //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                //cube.transform.position = hitInfo.point;
            }
        }

        float distance = Vector3.Distance(transform.position, _target); //distance = between player & destination
        if (distance < 1.0f) //if distance is less than 1 stop animation
        {
            _anim.SetBool("Walk", false);
        }

    }
}
