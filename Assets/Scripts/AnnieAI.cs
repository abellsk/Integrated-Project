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

    public static AnnieAI instance;

    private int currentCheckpointIndex;

    NavMeshAgent annie;

    [SerializeField] 
    Transform playerToChase;


    Player activEplayer = null;

    //private float speed = 0.5f;

    private void Awake()
    {
        annie = GetComponent<NavMeshAgent>();
        
        if (instance != null && instance != this)
        {
            // If true, I'm not needed and can be destroyed.
            Destroy(gameObject);
        }
        else
        {
            //Set the GameManager to not be destroyed when scenes are loaded.
            DontDestroyOnLoad(gameObject);

            

            // Set myself as the instance
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        activEplayer = GameManager.instance.activePlayer;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerToChase != null)
        {
            annie.SetDestination(activEplayer.transform.position);
        }
    }

    public void SetThingToChase(Transform thingToSet)
    {
        playerToChase = thingToSet;
    }

    
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.
    }
    */
}
