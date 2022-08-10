using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellReset : MonoBehaviour
{
    public GameObject Bell;

    static string tagBell = "Bell";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Bell.gameObject.tag = tagBell;
        }
    }
}
