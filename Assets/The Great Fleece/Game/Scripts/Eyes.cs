using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    //create the ability to detect darren when he's caught in our eye

    //void ontriggerenter
    //check that it's darren (tag of player)
    //enable the game over cutscene
    public GameObject gameOverCutscene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameOverCutscene.SetActive(true);
        }
    }
}
