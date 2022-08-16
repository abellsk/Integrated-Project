using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour
{
    /// <summary>
    /// The index of the scene to load to.
    /// </summary>
    public int sceneToLoad;

    /// to store switch
    public static Switch instance;

    /// start the timer to time how long the game has been running.
    float runTimer = 0f;
    string gameEnd;

    /// to counthow manytimes player has came back to lobby.
    int lobbyCount = 0;

    /// <summary>
    /// The interact function called by the player.
    /// </summary>
    public void Interact()
    {
        Debug.Log(gameObject.name +  " interacted");
        // use the SceneManager to load the specified scene index.
        SceneManager.LoadScene(sceneToLoad);
        
    }

    public void runTime()
    {
        if (sceneToLoad == 1)
        {
            lobbyCount++;
            runTimer += Time.deltaTime;
            Debug.Log(runTimer);
        }

        if (sceneToLoad == 1 && lobbyCount > 1)
        {
            Debug.Log("game end");
            runTimer = 0f;
            gameEnd = runTimer.ToString();
            Debug.Log(gameEnd);
        }
    }
}
