using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnnieAI : MonoBehaviour
{
    public string currentState;

    public string nextState;

    public float idleTime;

    public Transform[] checkpoints;

    private int currentCheckpointIndex;

    NavMeshAgent annie;

    [SerializeField] 
    Transform playerToChase;

    private float speed = 0.5f;

    private void Awake()
    {
        annie = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerToChase != null)
        {
            annie.SetDestination(playerToChase.position);
        }
    }

    public void SetThingToChase(Transform thingToSet)
    {
        playerToChase = thingToSet;
    }
}
