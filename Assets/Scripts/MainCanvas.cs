using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvas : MonoBehaviour
{
    [SerializeField] GameObject[] panels;
    [SerializeField] GameObject[] maps;
    [SerializeField] Text[] resultTexts;
    [SerializeField] Text[] CETexts;
    int curPanel;
    bool isWohan;
    int wayToWuHan;
    float distanceToWuHan;
    int wayToHust;
    float distanceToHust;
    // Start is called before the first frame update
    void Start()
    {
        curPanel = 0;
        isWohan = false;
        wayToWuHan = 0;
        distanceToWuHan = 0;
        wayToHust = 0;
        distanceToHust = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePanel()
    {
        panels[curPanel].SetActive(false);
        curPanel++;
        panels[curPanel].SetActive(true);
    }

    public void SetWuhan(bool b)
    {
        isWohan = b;
    }

    public void SetWayToWuhan(int i)
    {
        wayToWuHan = i;
    }

    public void SetDistanceToWuhan(float i)
    {
        distanceToWuHan = i;
    }
    public void SetChanaMap(bool op)
    {
        maps[0].SetActive(op);
    }
    public void SetWuHanMap(bool op)
    {
        maps[1].SetActive(op);
    }
    public void SetWayToHust(int i)
    {
        wayToHust = i;
    }
    public void SetDistanceToHust(float f)
    {
        distanceToHust = f;
    }
    public void Calculate()
    {
        float CEAll = 0;
        float CEToWuhan = 0;
        float CEToHust = 0;
        if (!isWohan)
        {
                resultTexts[0].text = resultTexts[0].text.Replace("<distance>", distanceToWuHan.ToString("0.00"));
            if(wayToWuHan == (int)ETraffic.car)
            {
                CEToWuhan = distanceToWuHan/100*0.024f;
                distanceToHust = 0;
                resultTexts[1].text = resultTexts[1].text.Replace("<distance>", "ºöÂÔ");
            }
            else if(wayToWuHan == (int)ETraffic.train)
            {
                CEToWuhan = distanceToWuHan / 100 * 0.0011f;
                distanceToHust = 18;
                resultTexts[1].text = resultTexts[1].text.Replace("<distance>", distanceToHust.ToString("0.00"));
            }
            else if(wayToWuHan == (int)ETraffic.air)
            {
                CEToWuhan = distanceToWuHan / 100 * 0.014f;
                distanceToHust = 48;
                resultTexts[1].text = resultTexts[1].text.Replace("<distance>", distanceToHust.ToString("0.00"));
            }
        }
        else
        {
            resultTexts[0].text = resultTexts[0].text.Replace("<distance>", distanceToWuHan.ToString("0.00"));
            resultTexts[1].text = resultTexts[1].text.Replace("<distance>", distanceToHust.ToString("0.00"));
        }

        if (wayToHust == (int)ETraffic.car)
        {
            CEToHust = distanceToHust / 100 * 0.014f;
        }
        else if (wayToHust == (int)ETraffic.bus)
        {
            CEToHust = distanceToHust / 100 * 0.0032f;
        }
        else if (wayToHust == (int)ETraffic.subway)
        {
            CEToHust = distanceToHust / 48 * 32 / 10 * 0.0013f;
        }
        CEAll = CEToHust + CEToWuhan;

        resultTexts[2].text = resultTexts[2].text.Replace("<distance>", CEAll.ToString());
        CETexts[0].text = CETexts[0].text.Replace("<amount>", (CEAll / 0.024 * 100).ToString("0.00"));
        CETexts[1].text = CETexts[1].text.Replace("<amount>", (CEAll / 0.005).ToString("0.00"));
        CETexts[2].text = CETexts[2].text.Replace("<amount>", (CEAll / 0.006).ToString("0.00"));
        CETexts[3].text = CETexts[3].text.Replace("<amount>", (CEAll / 0.042).ToString("0.00"));
        CETexts[4].text = CETexts[4].text.Replace("<amount>", (CEAll / 0.012).ToString("0.00"));

    }
    public void changePanelTo(int i)
    {
        panels[curPanel].SetActive(false);
        curPanel = i;
        panels[curPanel].SetActive(true);
    }
}

public enum  ETraffic
{
    air,
    train,
    car,
    bus,
    subway
}
