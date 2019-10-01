using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemRoot : MonoBehaviour
{
    public ResSever resSever;
    public AudioSer audioSer;
    protected NetSvc netSvc;

    public virtual void IniSys()
    {
        resSever = ResSever.Instance;
        audioSer = AudioSer.Instance;
        netSvc = NetSvc.Instance;
    }
}
