using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    //Check for Trigger of Player
    //Update main camera to appropriate angel
    //check for trigger
    //debug.log trigger activated

    public Transform myCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Player")
        {
            Debug.Log("Trigger Activated");
            Camera.main.transform.position = myCamera.transform.position;
            Camera.main.transform.rotation = myCamera.transform.rotation;
        }
    }

}
