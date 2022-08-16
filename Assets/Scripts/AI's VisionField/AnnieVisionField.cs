using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnieVisionField : MonoBehaviour
{
    public AnnieAI annieAI;

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //annieAI.SeePlayer(null);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //annieAI.SeePlayer(other.transform);
        }
    }
}
