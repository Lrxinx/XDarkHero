using PEProtocol;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanle : WindowRoot
{
    public Button enterGame;
    public Button infomation;
    public InputField acount;
    public InputField password;

    protected override void IniPanle()
    {
        base.IniPanle();
        enterGame.onClick.AddListener(OnClickEnter);
        infomation.onClick.AddListener(OnClickNotice);
        if (PlayerPrefs.HasKey("acount") && PlayerPrefs.HasKey("password"))
        {
            acount.text = PlayerPrefs.GetString("acount");
            password.text = PlayerPrefs.GetString("password");
        }
        else
        {
            acount.text = "";
            password.text = "";
        }
        
         ///TODO upadte local date;
         ///

        
    }
    
    private void OnClickEnter()
    {
        AudioSer.Instance.PlayUIAudio(Constant.EnterBtnName);

        string acount = this.acount.text;
        string passWord = this.password.text;

        if (acount != "" && passWord != "")
        {
            //update local acount information;
            PlayerPrefs.SetString("acount", acount);
            PlayerPrefs.SetString("password", passWord);

            //Send Network Messages To Request Login;
            GameMessage message = new GameMessage
            {
                cmd = (int)CMD.ReqLogin,
                reqLogin = new ReqLogin { account = acount, password = passWord }
            };


            netSvc.SendMessage(message);

            ///Simulate Login Succeed;
            //LoginSystem.Instance.RspLogin();

        }
        else if (acount == "" && passWord == "")
            GameRoot.AddTips("Please Input Acounr Information!");
        else if (acount == "")
            GameRoot.AddTips("Please Input Acount");
        else if (passWord == "")
            GameRoot.AddTips("Please Input PassWord!");
       
    }

    private void OnClickNotice()
    {
        AudioSer.Instance.PlayUIAudio(Constant.UIClickName);
    }
}
