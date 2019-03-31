using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Scripts")]
    public SpawnObject spawnObject;
    public PlayerMovement PlayerMovement;

    [Header("Components")]
    public Text score;
    //Holds the buttons for movement
    public GameObject playerMovementButtons;
    public int knifesDodged;

    [Header("Menu System")]
    public GameObject Panel;
    public GameObject Controls;
    public GameObject Menu;
    int count = 0;
    public bool panelVisible = true;

    private void Awake()
    {
        score.GetComponent<Text>();
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    private void Update()
    {
        knifesDodged = spawnObject.knifesSpawned;
        score.text = " Knifes: " + knifesDodged.ToString();

        if (panelVisible == true)
        {
            spawnObject.CancelSpawns();
            playerMovementButtons.SetActive(false);
        }
    }

    public void Accelerometer()
    {
        PlayerMovement.ButtonMovement = false;
        playerMovementButtons.SetActive(false);
    }

    public void MovementByButtons()
    {
        PlayerMovement.ButtonMovement = true;
        playerMovementButtons.SetActive(true);
    }

    // Menu system controls

    public void OptionsFunction()
    {
        Menu.SetActive(false);
        Controls.SetActive(true);
    }

    public void PauseButton()
    {
        count++;
        if (count == 1)
        {
            Panel.SetActive(true);
            spawnObject.CancelSpawns();
            panelVisible = true;
            PlayerMovement.rb.GetComponent<Rigidbody>().velocity = Vector3.zero;
            playerMovementButtons.SetActive(false);
        }

        if (count == 2)
        {
            count = 0;
            Panel.SetActive(false);
            spawnObject.spawnKnifes();
            playerMovementButtons.SetActive(true);
            spawnObject.spawnKnifes();
        }
    }

    public void startGame()
    {
        Panel.SetActive(false);
        panelVisible = false;
        playerMovementButtons.SetActive(true);
        spawnObject.spawnKnifes();
    }

}
