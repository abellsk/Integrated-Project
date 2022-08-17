using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScare : MonoBehaviour
{
    public Animator doorAnimator;

    int bellringCountchecker;

    private void Start()
    {
        //bellringCountchecker = Player.player.bellRungCount;
    }

    private void Update()
    {
        //Debug.Log(bellringCountchecker);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            doorAnimator.SetBool("PressurePlate", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            doorAnimator.SetBool("PressurePlate", false);
        }
    }
}
