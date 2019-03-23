﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayerMovement PlayerMovement;

    public GameObject playerMovementButtons;

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
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
