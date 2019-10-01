using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatPlayerPanle : WindowRoot
{

    public InputField iptName;
    public Button btn_RandomName;
    public Button enterGame;
    protected override void IniPanle()
    {
        base.IniPanle();

        iptName.text = resSever.GetRandomName(false);
        btn_RandomName.onClick.AddListener(OnClickRandomName);
        enterGame.onClick.AddListener(OnClickEnterGame);
    }

    private void OnClickRandomName()
    {
        audioSer.PlayUIAudio(Constant.UIClickName);
        iptName.text = resSever.GetRandomName(false);
    }
    private void OnClickEnterGame()
    {
        audioSer.PlayUIAudio(Constant.UIClickName);
        if (iptName.text != "")
        {
            ///Enter Game 
        }
        else
            GameRoot.AddTips("Please Input Right Name");
    }
}
