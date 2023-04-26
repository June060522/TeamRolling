using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PictureMinigame : MonoBehaviour
{
    public static PictureMinigame instance;

    private GridLayoutGroup gridLayoutGroup;
    [SerializeField] Picture[] pictures;
    [SerializeField] TextMeshProUGUI time;
    [SerializeField] Sprite noneSprite;
    public bool isplaying = false;
    public bool isDelay = false;
    int maxcnt = 0;
    int iCnt = 100;
    float playtime = 0f;

    GameObject pickFirst = null;
    GameObject pickSecond = null;
    

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogError("PictureMinigame is Multiple");

        gridLayoutGroup = GetComponent<GridLayoutGroup>();
    }

    private void OnEnable()
    {
        if (transform.childCount != 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(gameObject.transform.GetChild(i).gameObject);
            }
        }
        isplaying = false;
        playtime = 0;

        MiniGameSetting(4);
    }

    private void Update()
    {
        if (isplaying)
            playtime += Time.deltaTime;
        if(playtime > 15)
            playtime = 15;
        time.text = string.Format("{0:0.#}",15 - playtime);

        //if ((playtime >= 15f || iCnt == 0) && isplaying)
        //    EndGame();

        if(pickFirst != null && pickSecond != null && !isDelay)
        {
            isDelay = true;
            if (pickFirst.GetComponent<Picture>().index == pickSecond.GetComponent<Picture>().index)
            {
                StartCoroutine(Answer());
            }
            else
            {
                StartCoroutine(Wrong());
            }
        }
    }

    IEnumerator Answer()
    {
        yield return new WaitForSeconds(0.1f);
        pickFirst.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        pickSecond.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        iCnt--;
        pickFirst = null;
        pickSecond = null;
        isDelay = false;
    }

    IEnumerator Wrong()
    {
        yield return new WaitForSeconds(0.2f);
        pickFirst.GetComponent<Button>().interactable = true;
        pickSecond.GetComponent<Button>().interactable = true;
        pickFirst.GetComponent<Image>().sprite = noneSprite;
        pickSecond.GetComponent<Image>().sprite = noneSprite;
        pickFirst = null;
        pickSecond = null;
        isDelay = false;
    }
    public void MiniGameSetting(int cnt)
    {
        List<Picture> s = new List<Picture>();
        gridLayoutGroup.constraintCount = (int)Mathf.Sqrt(cnt * 2);
        maxcnt = cnt;
        iCnt = maxcnt;
        for (int i = 0; i < maxcnt; i++)
        {
            Picture p = pictures[i];
            p.name = i.ToString();
            Picture p1 = pictures[i];
            p1.name = i.ToString();
            p.setting(i);
            p1.setting(i);
            s.Add(p);
            s.Add(p1);
        }

        for(int i = 0; i < maxcnt * 2; ++i)
        {
            int idx = Random.Range(0, s.Count);
            Picture p = Instantiate(s[idx],this.transform);
            p.GetComponent<Image>().sprite = p.GetComponent<Picture>().image;
            s.RemoveAt(idx);
        }

        StartCoroutine(ShowPicture());
    }

    IEnumerator ShowPicture()
    {
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < transform.childCount; ++i)
        {
            transform.GetChild(i).GetComponent<Image>().sprite = noneSprite;
        }
        isplaying = true;
    }

    public bool EndGame(out float value)
    {
        Debug.Log("°¨ÁöÁß...");
        if (iCnt == 0)
        {
            Debug.Log("ÀÌ±è");
            value = 30 - (playtime / 2);
            return true;
        }
        else if(playtime >= 15)
        {
            Debug.Log("Áü");//³»°¡ ÀÌ°å´Âµ¥????? ³»°¡ ÀÌ°å´Ù°í ¾ß ³»°¡ ÀÌ±è
            value = 0;
            return true;
        }

        //isplaying = false;
        value = 0;
        return false;
    }

    public void Pick(GameObject g)
    {
        if (pickFirst == null)
            pickFirst = g;
        else
            pickSecond = g;
    }
}
