using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VisionField : MonoBehaviour
{
    public ReceptionistAI attachedAI;

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            attachedAI.SeePlayer(null);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            attachedAI.SeePlayer(other.transform);
        }
    }


}

