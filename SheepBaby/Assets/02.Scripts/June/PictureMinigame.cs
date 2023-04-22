using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureMinigame : MonoBehaviour
{
    public static PictureMinigame instance;

    private GridLayoutGroup gridLayoutGroup;
    [SerializeField] Picture[] pictures;
    int maxcnt = 0;
    int iCnt = 0;
    float playtime = 0f;
    bool isplaying = false;

    int pickFirst = -1;
    int pickSecond = -2;
    

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
        isplaying = false;
        playtime = 0;
    }
    private void Start()
    {
        MiniGameSetting(4);
    }

    private void Update()
    {
        if (isplaying)
            playtime += Time.deltaTime;

        if (playtime >= 10f)
            EndGame();

        if(pickFirst >= 0 && pickSecond >= 0)
        {
            if (pickFirst == pickSecond)
            {
                Debug.Log("¸Â¾Ò½À´Ï´Ù.");
            }
            else if(pickFirst != pickSecond)
            {
                Debug.Log("Æ²·È½À´Ï´Ù.");
            }
            pickFirst = -1;
            pickSecond = -2;
        }
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
            s.RemoveAt(idx);
        }    
    }

    public void EndGame()
    {
        if (iCnt == 0)
            Debug.Log("ÀÌ±è");
        else
            Debug.Log("Áü");
    }

    public void Pick(int idx)
    {
        if (pickFirst < 0)
            pickFirst = idx;
        else
            pickSecond = idx;
    }
}
