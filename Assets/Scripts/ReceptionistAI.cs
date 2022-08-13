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

    private Transform playerToApproach;

    private float minimumDistance = 1f;

    private float speed = 0.5f;

    public GameObject welcomeTxt;

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
        playerToApproach = player;

        nextState = "Approach";
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
    
    IEnumerator Approach()
    {
        while (currentState == "Approach")
        {
            
            yield return null;

            if (playerToApproach != null)
            {
                if (Vector3.Distance(transform.position, playerToApproach.position) > minimumDistance)
                {
                    Debug.Log("now approach");
                    transform.position = Vector3.MoveTowards(transform.position, playerToApproach.position, speed * Time.deltaTime);
                    welcomeTxt.SetActive(true);

                }
            }
            else
            {
                // nothing
                nextState = "Idle";
            }

            
        }
        SwitchState();      
    }
    
}
