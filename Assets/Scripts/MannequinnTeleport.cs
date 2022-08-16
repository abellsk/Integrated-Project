using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MannequinnTeleport : MonoBehaviour
{
    public GameObject playerRef;
    public static MannequinnTeleport instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBecameInvisible()
    {
        if (playerRef)
        {
            transform.position = playerRef.transform.position - playerRef.transform.forward;

            Vector3 lookPos = playerRef.transform.position - transform.position;
            lookPos.y = 0f;
            transform.rotation = Quaternion.LookRotation(lookPos);
        }
    }
}
