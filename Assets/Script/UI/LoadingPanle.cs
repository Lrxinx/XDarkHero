using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingPanle : WindowRoot
{
    public Text text_tip;
    public Image prograss;
    public Image prograssTopPoint;
    public Text prograssText;
    private float progressWidth;
    protected override void IniPanle()
    {
        base.IniPanle();
        
        SetText(text_tip, "游戏提示其实不影响游戏体验哦...");
        prograss.fillAmount = 0;
        prograssTopPoint.GetComponent<RectTransform>().localPosition = new Vector3(-669f, 0, 0);
        SetText(prograssText, "0%");        
        progressWidth = prograss.GetComponent<RectTransform>().sizeDelta.x;
    }

    public void SetPrograss(float value)
    {
        prograss.fillAmount = value;      
        SetText(prograssText, (int)(value * 100) + "%");
        prograssTopPoint.GetComponent<RectTransform>().localPosition = new Vector3(value * progressWidth - progressWidth / 2, 0, 0);
    }
    
}
