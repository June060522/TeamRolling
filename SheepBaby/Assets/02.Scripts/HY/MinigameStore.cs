using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameStore : MonoBehaviour
{
    [SerializeField] private Button coloringTool;
    [SerializeField] private Button ball;
    [SerializeField] private Button snack;
    [SerializeField] private Button puzzle;
    [SerializeField] private Button consoleController;

    public bool isBuyColoringTool = false;
    public bool isBuyball = false;
    public bool isBuysnack = false;
    public bool isBuypuzzle = false;
    public bool isBuyconsoleController = false;

    public void ColoringToolButtonEnable()
    {
        coloringTool.enabled = false;
        isBuyColoringTool = true;
    }

    public void BallButtonEnable()
    {
        ball.enabled = false;
        isBuyball = true;
    }

    public void SnackButtonEnable()
    {
        snack.enabled = false;
        isBuysnack = true;
    }

    public void PuzzleButtonEnable()
    {
        puzzle.enabled = false;
        isBuypuzzle = true;
    }

    public void ConsoleControllerButtonEnable()
    {
        consoleController.enabled = false;
        isBuyconsoleController = true;
    }
}
