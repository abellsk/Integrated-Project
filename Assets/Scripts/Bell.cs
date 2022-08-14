using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : MonoBehaviour
{
    public static Bell action;
    public void Ring()
    {
        GetComponent<AudioSource>().Play();
    }
}
