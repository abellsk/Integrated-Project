using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellReset : MonoBehaviour
{

    public static BellReset action;
    public GameObject Bell;

    static string tagBell = "Bell";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Bell has been reset.");
            Bell.gameObject.tag = tagBell;
        }
    }

}
