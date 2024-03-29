using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// The prefab of the player used for spawning.
    /// </summary>
    public GameObject playerPrefab;

    /// <summary>
    /// Store the active player in the game.
    /// </summary>
    public Player activePlayer;

    /// <summary>
    /// Store the active GameManager.
    /// </summary>
    public static GameManager instance;

    /// <summary>
    /// True when the game is paused.
    /// </summary>
    private bool gamePaused;

    /// <summary>
    /// The pause menu of the game.
    /// </summary>
    public GameObject pauseMenu;

    /// <summary>
    /// The respawn menu of the game.
    /// </summary>
    public GameObject respawnMenu;

    /// <summary>
    /// The end menu of the game.
    /// </summary>
    public GameObject completeMenu;

    /// <summary>
    /// Enabling of doors
    /// </summary>
    public GameObject doorOpen;
    public GameObject doorClosed;

    ///<summary>
    /// The Camera Ui of the player
    /// </summary>

    public GameObject cameraFourbatt;
    public GameObject cameraThreebatt;
    public GameObject cameraTwobatt;
    public GameObject cameraOnebatt;

    /// <summary>
    /// Timer to show how long it took for the player
    /// </summary>
    float runTimer = 0f;

    /// <summary>
    /// Teleport location for mannequins
    /// </summary>
    public GameObject locationOne;
    public GameObject locationTwo;
    public GameObject locationThree;
    public GameObject locationFour;
    public GameObject locationFive;
    public GameObject locationSix;
    public GameObject locationSeven;
    public GameObject locationEight;
    public GameObject locationNine;
    public GameObject locationTen;
    public GameObject locationEleven;
    public GameObject locationTwelve;
    public GameObject locationThirteen;
    public GameObject locationFourteen;
    public GameObject locationFiveteen;
    public GameObject locationSixteen;
    public GameObject locationSeventeen;
    public GameObject locationEightteen;

    /// <summary>
    /// assign mannequins to teleport them
    /// </summary>
    public GameObject mannequinOne;
    public GameObject mannequinTwo;
    public GameObject mannequinThree;
    public GameObject mannequinFour;
    public GameObject mannequinFive;
    public GameObject mannequinSix;
    public GameObject mannequinSeven;
    public GameObject mannequinEight;
    public GameObject mannequinNine;
    public GameObject mannequinTen;
    public GameObject mannequinEleven;
    public GameObject mannequinTwelve;
    public GameObject mannequinThirteen;
    public GameObject mannequinFourteen;
    public GameObject mannequinFiveteen;
    public GameObject mannequinSixteen;
    public GameObject mannequinSeventeen;
    public GameObject mannequinEighteen;

    /// <summary>
    /// animator for door
    /// </summary>
    public Animator doorAnimatorOne;
    //public Animator doorAnimatorTwo;
    public Animator doorOneAnimatorTop;
    public Animator doorTwoAnimatorTop;
    public Animator doorThreeAnimatorTop;
    public Animator finishedDoor;
    public Animator anotherDoor;

    /// <summary>
    /// to store fake annie to scare 
    /// </summary>
    public GameObject fakeAnnie;

    /// <summary>
    /// To display decals
    /// </summary>
    public GameObject decalOne;
    public GameObject decalTwo;
    public GameObject decalThree;
    public GameObject decalFour;
    public GameObject decalFive;
    public GameObject decalSix;
    public GameObject decalSeven;
    public GameObject decalEight;
    public GameObject decalNine;
    public GameObject decalTen;
    public GameObject decalEleven;
    public GameObject decalTwelve;

    /// <summary>
    /// to replace the door
    /// </summary>
    public GameObject movedDoor;
    public GameObject correctDoor;
    public GameObject normalDoor;


    /// <summary>
    /// Crosshairfor the player
    /// </summary>
    public GameObject playerCrosshair;

    /// <summary>
    /// to update how many evidence has been collected
    /// </summary>
    int evidenceChecker;
    public GameObject evidenceZero;
    public GameObject evidenceFirst;
    public GameObject evidenceSecond;
    public GameObject evidenceThird;
    public GameObject evidenceFour;
    public GameObject evidenceFive;
    public GameObject evidenceSix;

    private void Awake()
    {
        // Check whether there is an instance
        // Check whether the instance is me
        if(instance != null && instance != this)
        {
            // If true, I'm not needed and can be destroyed.
            Destroy(gameObject);
        }
        // If not, set myself as the instance
        else
        {
            //Set the GameManager to not be destroyed when scenes are loaded.
            DontDestroyOnLoad(gameObject);

            // Subscribe the spawning function to the activeSceneChanged event.
            SceneManager.activeSceneChanged += SpawnPlayerOnLoad;

            // Set myself as the instance
            instance = this;
        }
    }

    private void Update()
    {
        evidenceChecker = Player.evidenceCollected;
        if (evidenceChecker == 1)
        {
            evidenceZero.SetActive(false);
            evidenceFirst.SetActive(true);
        }
        else if (evidenceChecker == 2)
        {
            evidenceFirst.SetActive(false);
            evidenceSecond.SetActive(true);
        }
        else if (evidenceChecker == 3)
        {
            evidenceSecond.SetActive(false);
            evidenceThird.SetActive(true);
        }
        else if (evidenceChecker == 4)
        {
            evidenceThird.SetActive(false);
            evidenceFour.SetActive(true);
        }
        else if (evidenceChecker == 5)
        {
            evidenceFour.SetActive(false);
            evidenceFive.SetActive(true);
        }
        else if (evidenceChecker == 6)
        {
            evidenceFive.SetActive(false);
            evidenceSix.SetActive(true);
        }
    }

    /// <summary>
    /// Spawn the player when the scene changes
    /// </summary>
    /// <param name="currentScene"></param>
    /// <param name="nextScene"></param>
    void SpawnPlayerOnLoad(Scene currentScene, Scene nextScene)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {

        }
        else { 
            // Checking if there is any active player in the game.
            if(activePlayer == null)
            {
                // Find the spawn spot
                PlayerSpawnSpot playerSpot = FindObjectOfType<PlayerSpawnSpot>(); //changed playerspot to PlayerSpawnSpot

                // If there is no player, I should spawn one.
                GameObject newPlayer = Instantiate(playerPrefab, playerSpot.transform.position, playerSpot.transform.rotation);

                // Store the active player.
                activePlayer = newPlayer.GetComponent<Player>();
            }
            // If there is already a player, position the player at the right spot.
            else
            {
                // Find the spawn spot
                PlayerSpawnSpot playerSpot = FindObjectOfType<PlayerSpawnSpot>(); //changed playerspot to PlayerSpawnSpot

                // Position and rotate the player
                activePlayer.transform.position = playerSpot.transform.position;
                activePlayer.transform.rotation = playerSpot.transform.rotation;
            }
        }
    }

    /// <summary>
    /// Toggles the pause state of the game.
    /// </summary>
    public void TogglePause()
    {
        // Check if the game is not paused
        if(!gamePaused)
        {
            // If the game is not paused, pause it by setting timeScale to 0
            Time.timeScale = 0f;
            gamePaused = true;
            pauseMenu.SetActive(gamePaused);
        }
        else
        {
            // If the game is paused, unpause it
            Time.timeScale = 1f;
            gamePaused = false;
            pauseMenu.SetActive(gamePaused);
        }
    }

    /// <summary>
    /// Starts the game
    /// </summary>
    public void StartGame()
    {
        LoadScene(1);
        //ToggleOffRespawnMenu();
        //Switch.instance.runTime();
        playerCrosshair.SetActive(true); 
    }

    /// <summary>
    /// Ends the game
    /// </summary>
    public void EndGame()
    {
        Destroy(activePlayer.gameObject);
        ToggleOffRespawnMenu();
        TogglePause();
        LoadScene(0);
    }

    /// <summary>
    /// Restarts the game
    /// </summary>
    public void RestartGame()
    {
        activePlayer.ResetPlayer();
        ToggleOffRespawnMenu();
        StartGame();
    }

    /// <summary>
    /// Loads the scene specified by <paramref name="sceneIndex"/>
    /// </summary>
    /// <param name="sceneIndex">The index of the scene to load</param>
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    /// <summary>
    /// Toggles the respawn menu
    /// </summary>
    public void ToggleRespawnMenu()
    {
        respawnMenu.SetActive(true);
    }

    /// <summary>
    /// Toggles the respawn menu
    /// </summary>
    public void ToggleOffRespawnMenu()
    {
        respawnMenu.SetActive(false);
    }


    /// <summary>
    /// Shows the end menu
    /// </summary>
    public void ShowCompleteMenu()
    {
        completeMenu.SetActive(true);
    }
    
    /// <summary>
    /// Swicth to a new active door
    /// </summary>
    public void ShowDoor()
    {
        if (doorClosed.activeSelf == true)
        {
            doorOpen.SetActive(true);
            doorClosed.SetActive(false);
        }
        else if (doorClosed.activeSelf == false)
        {
            doorOpen.SetActive(false);
            doorClosed.SetActive(true);
        }
    }

    public void showCamera()
    {
        cameraFourbatt.SetActive(true);
    }

    public void offCamera()
    {
        cameraFourbatt.SetActive(false);
    }

    public void mannequinTeleport()
    {
        mannequinOne.transform.position = locationOne.transform.position;
        mannequinTwo.transform.position = locationTwo.transform.position;
        mannequinFive.transform.position = locationFive.transform.position;
        mannequinThree.transform.position = locationThree.transform.position;
        mannequinFour.transform.position = locationFour.transform.position;
        mannequinSix.transform.position = locationSix.transform.position;
        mannequinSeven.transform.position = locationSeven.transform.position;
        mannequinEight.transform.position = locationEight.transform.position;
        mannequinNine.transform.position = locationNine.transform.position;
        mannequinTen.transform.position = locationTen.transform.position;
        mannequinEleven.transform.position = locationEleven.transform.position;
        mannequinTwelve.transform.position = locationTwelve.transform.position;
        mannequinThirteen.transform.position = locationThirteen.transform.position;
        mannequinFourteen.transform.position = locationFourteen.transform.position;
        mannequinFiveteen.transform.position = locationFiveteen.transform.position;
        mannequinSixteen.transform.position = locationSixteen.transform.position;
        mannequinSeventeen.transform.position = locationSeventeen.transform.position;
        mannequinEighteen.transform.position = locationEightteen.transform.position;
    }

    public void doorOpenAnimation()
    {
        doorAnimatorOne.SetBool("DoorInteracted", true);
    }

    public void doorTwoOpenAnimation()
    {
        //doorAnimatorTwo.SetBool("DoorInteracted", true);
    }

    public void doorTopOpenAnimation()
    {
        doorOneAnimatorTop.SetBool("finalRing", true);
        doorTwoAnimatorTop.SetBool("LastRing", true);
        doorThreeAnimatorTop.SetBool("DoorInteracted", true);
    }

    public void finshedDoorAnim()
    {
        finishedDoor.SetBool("fiveRings", true);
    }

    public void anotherDoorAnim()
    {
        anotherDoor.SetBool("fifthRing", true);
    }

    public void showDecals()
    {
        decalOne.SetActive(true);
        decalTwo.SetActive(true);
        decalThree.SetActive(true);
        decalFour.SetActive(true);
        decalFive.SetActive(true);
        decalSix.SetActive(true);
        decalSeven.SetActive(true);
        decalEight.SetActive(true);
        decalNine.SetActive(true);
        decalTen.SetActive(true);
        decalEleven.SetActive(true);
        decalTwelve.SetActive(true);    
    }

    public void offAnnie()
    {
        fakeAnnie.SetActive(false);
    }

    public void resetDoor()
    {
        if(normalDoor.activeSelf == true)
        {
            movedDoor.SetActive(true);
            normalDoor.SetActive(false);
        }
        else
        {
            normalDoor.SetActive(false);
            movedDoor.SetActive(false);
            correctDoor.SetActive(true);
        }
    }
}
