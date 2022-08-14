using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : MonoBehaviour
{
    public void Ring()
    {
        GetComponent<AudioSource>().Play();
    }
}
