using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicWind : WindowRoot
{
    public Animation tipAnimate;
    public Text tipText;
    private Queue<string> tipsQue = new Queue<string>();

    private bool isTipPlay;

    protected override void IniPanle()
    {
        base.IniPanle();
        SetActive(tipText, false);
    }

    public void AddTip(string tip)
    {
        lock (tipsQue)
        {
            tipsQue.Enqueue(tip);
        }
        
    }
    private void Update()
    {
        if (tipsQue.Count > 0&&isTipPlay==false)
        {
            lock (tipsQue)
            {
                string tip = tipsQue.Dequeue();
                SetTip(tip);
                isTipPlay = true;
            }
        }
    }
    private void SetTip(string tip)
    {
        SetActive(tipText, true);
        SetText(tipText, tip);

        AnimationClip clip = tipAnimate.GetClip("Text_PopTop");

        ///close
        StartCoroutine(AniPlayDone(clip.length, () => SetActive(tipText, false)));
    }
    IEnumerator AniPlayDone(float time,Action action)
    {
        yield return new WaitForSeconds(time);
        if (action != null)
            action();
        isTipPlay = false;
    }
}
