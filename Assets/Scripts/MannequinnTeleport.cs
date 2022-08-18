using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MannequinnTeleport : MonoBehaviour
{
    GameObject playerRef;
    int bellCountChecker;

    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        bellCountChecker = Player.bellRungCount;
    }

    public void OnBecameInvisible()
    {
        if (playerRef & bellCountChecker == 3)
        {
            transform.position = playerRef.transform.position - playerRef.transform.forward;

            Vector3 lookPos = playerRef.transform.position - transform.position;
            lookPos.y = 0f;
            transform.rotation = Quaternion.LookRotation(lookPos);
        }
    }
}
