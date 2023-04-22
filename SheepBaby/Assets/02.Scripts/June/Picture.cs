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
        if(PictureMinigame.instance.isplaying)
        {
            GetComponent<Button>().interactable = false;
            GetComponent<Image>().sprite = image;
            PictureMinigame.instance.Pick(this.gameObject);
        }
    }
}
