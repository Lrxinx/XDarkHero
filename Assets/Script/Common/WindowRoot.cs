using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowRoot : MonoBehaviour
{
    protected ResSever resSever;
    protected AudioSer audioSer;
    protected NetSvc netSvc;
   public void SetWindState(bool isActive = true)
    {
        if (gameObject.activeSelf != isActive)
            SetActive(gameObject, isActive);
        if (isActive)
            IniPanle();
        else
            ClearPanle();
    }

    protected virtual void IniPanle()
    {
        resSever = ResSever.Instance;
        audioSer = AudioSer.Instance;
        netSvc = NetSvc.Instance;
    }

    protected virtual void ClearPanle()
    {
        resSever = null;
        audioSer = null;
        netSvc = null;
    }

    #region SetActive
    protected void SetActive(GameObject gameObject,bool isActive=true)
    {
        gameObject.SetActive(isActive);
    }

    protected void SetActive(Transform transform, bool isActive = true)
    {
        transform.gameObject.SetActive(isActive);
    }
    protected void SetActive(Image image, bool isActive = true)
    {
        image.transform.gameObject.SetActive(isActive);
    }

    protected void SetActive(Text text, bool isActive = true)
    {
        text.transform.gameObject.SetActive(isActive);
    }
    protected void SetActive(RectTransform rectTransform, bool isActive = true)
    {
        rectTransform.transform.gameObject.SetActive(isActive);
    }
    #endregion

    #region SetText
    protected void SetText(Text text,string content = "")
    {
        text.text = content;
    }
    protected void SetText(Text text, int content = 0)
    {
        text.text = content.ToString();
    }

    #endregion
}
