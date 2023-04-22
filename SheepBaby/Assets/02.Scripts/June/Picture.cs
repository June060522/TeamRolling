using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Picture : MonoBehaviour
{
    public int index;
    public Sprite image;

    public void setting(int index)
    {
        this.index = index;
    }

    public void Click()
    {
        PictureMinigame.instance.Pick(index);
        GetComponent<Button>().interactable = false;
    }
}
