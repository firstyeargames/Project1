using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Scripts")]
    public SpawnObject spawnObject;
    public PlayerMovement PlayerMovement;

    [Header("Components")]
    public Text score;
    public int knifesDodged;
    int count = 0;
    public bool panelVisible = true;
    bool pauseActive = false;
    bool accelermoterBool = false;

    [Header("Menu System")]
    public GameObject rightButton, leftButton;
    public GameObject Controls;
    public GameObject Menu;
    public GameObject pauseButton;


    private void Awake()
    {
        score.GetComponent<Text>();
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    private void Update()
    {
        if (spawnObject.player == null)
        {
            SceneManager.LoadScene(0);
        }
        knifesDodged = spawnObject.knifesSpawned;
        score.text = " Knifes: " + knifesDodged.ToString();
      
      if (panelVisible == true)
        {
            spawnObject.CancelSpawns();
            rightButton.SetActive(false);
            leftButton.SetActive(false);
        }

      if(accelermoterBool == true)
        {
            leftButton.SetActive(false);
            rightButton.SetActive(false);
        }

        if (spawnObject.player == null)
        {
            Menu.SetActive(true);
            panelVisible = true;
        }
    }

    public void Accelerometer()
    {
        PlayerMovement.UsingAccelerometerMovement();
        PlayerMovement.ButtonMovement = false;
        Controls.SetActive(false);
        startGame();
        accelermoterBool = true;
    }

    public void MovementByButtons()
    {
        PlayerMovement.ButtonMovement = true;
        rightButton.SetActive(true);
        leftButton.SetActive(true);
        startGame();
        Controls.SetActive(false);
    }

    // Menu system controls
    public void OptionsFunction()
    {
        Menu.SetActive(false);
        Controls.SetActive(true);
    }

    /// <summary>
    /// This function reduces real time to 0 meaning the game is paused
    /// if count is equal to 1 the game is paused
    /// if count is equal to 2 the game is resumed and count is equal to 0
    /// </summary>

    public void PauseButton()
    {
        count++;

        Menu.SetActive(true);
        panelVisible = true;
        pauseActive = true;
        Time.timeScale = 0f;
        Debug.Log("pause active true");
        pauseButton.SetActive(false);
        
        //if (count == 2)
        //{
        //    Panel.SetActive(false);
        //    pauseActive = false;
        //    Time.timeScale = 1.0f;
        //    spawnObject.spawnKnifes();
        //    count = 0;
        //    Debug.Log("pause active false");
        //}
    }

    /// <summary>
    ///  checking if the player is alive if not reload the level
    /// </summary>
    public void startGame()
    {
        Controls.SetActive(false);
        Menu.SetActive(false);
        panelVisible = false;
        spawnObject.spawnKnifes();
        Time.timeScale = 1.0f;
        pauseButton.SetActive(true);
        rightButton.SetActive(true);
        leftButton.SetActive(true);

    }

}
