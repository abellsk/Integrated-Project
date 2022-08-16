using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScare : MonoBehaviour
{
    public Animator doorAnimator;

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
