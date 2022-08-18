using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScare : MonoBehaviour
{
    public Animator doorAnimator;
    public Animator annieFirstScare;

    int bellringCountchecker;

    private void Start()
    {
        //bellringCountchecker = Player.player.bellRungCount;
    }

    private void Update()
    {
        bellringCountchecker = Player.bellRungCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && bellringCountchecker == 4)
        {
            doorAnimator.SetBool("PressurePlate", true);
            annieFirstScare.SetBool("TriggerPlate", true);
        }
    }
}
