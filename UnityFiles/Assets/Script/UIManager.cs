using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : ObjectDestruction
{
    [Header("Scripts")]
    public SpawnObject spawnObject;
    public PlayerMovement PlayerMovement;

    [Header("Components")]
    public Text score;
    public GameObject playerMovementButtons;
    public int knifesDodged;

    private void Awake()
    {
        score.GetComponent<Text>();
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    private void Update()
    {
        knifesDodged = spawnObject.knifesSpawned;
        score.text = " Knifes: " + knifesDodged.ToString();
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
}
