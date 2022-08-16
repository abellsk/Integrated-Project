using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    private int levelToLoad;

    /// start the timer to time how long the game has been running.
    float runTimer = 0f;
    string gameEnd;

    /// to counthow manytimes player has came back to lobby.
    int lobbyCount = 0;

    // Update is call once per frame
    private void Update()
    {
        if (levelToLoad > 1 )
        {
            FadeToLevel(1);
            FadeToNextLevel();
            runTime();
        }
        
    }

    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void onFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    /// <summary>
    /// The interact function called by the player.
    /// </summary>
    public void Interact()
    {
        Debug.Log(gameObject.name + " interacted");
        // use the SceneManager to load the specified scene index.
        SceneManager.LoadScene(levelToLoad);

    }

    public void runTime()
    {
        if (levelToLoad == 1)
        {
            lobbyCount++;
            runTimer += Time.deltaTime;
            Debug.Log(runTimer);
        }

        if (levelToLoad == 1 && lobbyCount > 1)
        {
            Debug.Log("game end");
            runTimer = 0f;
            gameEnd = runTimer.ToString();
            Debug.Log(gameEnd);
        }
    }
}
