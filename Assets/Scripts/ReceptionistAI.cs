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

    private Transform playerToChase;

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

    public void SeePlayer(Transform player)
    {
        playerToChase = player;

        nextState = "Chase";
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

    IEnumerator Chase()
    {
        while (currentState == "Chase")
        {
            yield return null;
            if(playerToChase != null)
            {
                receptionist.SetDestination(playerToChase.position);
            }
            else
            {
                nextState = "Idle";
            }
        }
        SwitchState();
    }
}
