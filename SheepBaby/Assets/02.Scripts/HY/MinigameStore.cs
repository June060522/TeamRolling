using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using Enum;

[System.Serializable]
public class ButtonData
{
    public Play playEnum;
    public Button button;
}

public class MinigameStore : MonoBehaviour
{
    public List<ButtonData> buttonList = new List<ButtonData>();
    public List<string> keys = new List<string>();

    BoyAbiliity boyAbiliity;

    public bool isBuyColoringTool { get; private set; }
    public bool isBuyball { get; private set; }
    public bool isBuysnack { get; private set; }
    public bool isBuypuzzle { get; private set; }
    public bool isBuyconsoleController { get; private set; }

    private void Awake() => boyAbiliity = FindObjectOfType<BoyAbiliity>();

    public void ButtonEnable(int num)
    {
        if (boyAbiliity.paper > 0)
        {
            keys.Add(buttonList[num].playEnum.ToString());
            buttonList[num].button.GetComponent<Image>().color = Color.gray;
            buttonList[num].button.enabled = false;

            boyAbiliity.paper--;
        }
    }
}
