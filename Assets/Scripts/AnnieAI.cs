using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnnieAI : MonoBehaviour
{
    public string currentState;

    public string nextState;

    public float idleTime;

    private NavMeshAgent annie;

    public Transform[] checkpoints;

    private int currentCheckpointIndex;

    private Transform playerToApproach;

    private float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SeePlayer(Transform player)
    {
        playerToApproach = player;

        nextState = "Approach";
    }
}
