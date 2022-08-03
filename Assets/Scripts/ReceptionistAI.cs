using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ReceptionistAI : MonoBehaviour
{
    public string currentState;
    public string nextState;

    public float idleTime;

    private NavMeshAgent receptionist;

    public Transform[] checkpoints;

    private int currentCheckpointIndex;

    void Start()
    {
        receptionist = GetComponent<NavMeshAgent>();

        currentState = "Idle";
        nextState = currentState;
        SwitchState();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != nextState)
        {
            currentState = nextState;
        }
        
    }

    void SwitchState()
    {
        StartCoroutine(currentState);
    }

    IEnumerator Idle()
    {
        while (currentState == "Idle")
        {
            yield return new WaitForSeconds(idleTime);

            nextState = "Patrol";
        }

        SwitchState();
    }

    IEnumerator Patrol()
    {
        receptionist.SetDestination(checkpoints[currentCheckpointIndex].position);
        bool hasReached = false;

        while (currentState == "Patrol")
        {
            yield return null;
            if(!hasReached)
            {
                if(receptionist.remainingDistance <= receptionist.stoppingDistance)
                {
                    hasReached = true;

                    nextState = "Idle";

                    currentCheckpointIndex++;

                    if (currentCheckpointIndex >= checkpoints.Length)
                    {
                        currentCheckpointIndex = 0;
                    }
                }
            }
        }

        SwitchState();   
    }
}
