using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    /// <summary>
    /// The index of the scene to load to.
    /// </summary>
    public int sceneToLoad;
    float timeR = 0f;
    /// <summary>
    /// The interact function called by the player.
    /// </summary>
    /// 

    private void Awake()
    {
        Interact();
        Debug.Log("scene changing...");
    }
    public void Interact()
    {
        Debug.Log("scene changing...");
        timeR += Time.deltaTime;
        if (timeR > 4f)
        {
            Debug.Log(gameObject.name + " interacted");
            // use the SceneManager to load the specified scene index.
            SceneManager.LoadScene(sceneToLoad);
            timeR = 0f;
        }
    }
}
