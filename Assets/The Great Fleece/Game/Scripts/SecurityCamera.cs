using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    public GameObject gameOverCutscene;
    public Animator anim;     //get a handle to the animator component


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //change the material
            MeshRenderer render = GetComponent<MeshRenderer>();
            Color color = new Color(0.6f, .1f, .11f, .04f);
            render.material.SetColor("_TintColor", color);
            anim.enabled = false;

            StartCoroutine(AlertRoutine());
        }
    }
    IEnumerator AlertRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        gameOverCutscene.SetActive(true); //call after o.5f
    }
}
