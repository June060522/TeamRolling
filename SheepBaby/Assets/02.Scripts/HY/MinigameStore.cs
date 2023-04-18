using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using Enum;

public class MinigameStore : MonoBehaviour
{
    public Play play;

    BoyAbiliity boyAbiliity;

    public bool isBuyColoringTool { get; private set; }
    public bool isBuyball { get; private set; }
    public bool isBuysnack { get; private set; }
    public bool isBuypuzzle { get; private set; }
    public bool isBuyconsoleController { get; private set; }

    private void Awake() => boyAbiliity = FindObjectOfType<BoyAbiliity>();

    public void ButtonEnable(Play playEnum ,Button button)
    {
        if (boyAbiliity.paper > 0)
        {
             = Play.dd;
            button.enabled = false;

            boyAbiliity.paper--;
        }
    }
}
