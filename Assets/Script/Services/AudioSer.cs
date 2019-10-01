using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSer : MonoBehaviour
{
    public static AudioSer Instance;

    public AudioSource bgAudio;
    public AudioSource uiAudio;

    public void IniAudioSer()
    {
        Instance = this;
       
    }

    public void PlayBgAudio(string clipName,bool isLoop = true)
    {
        AudioClip bgClip = ResSever.Instance.LoadAudoClip("ResAudio/" + clipName, true);
        
        if (bgAudio.clip == null || bgAudio.clip.name != bgClip.name)
        {
            bgAudio.clip = bgClip;
            bgAudio.loop = isLoop;
            bgAudio.Play();
        }
    }

    public void PlayUIAudio(string clipName)
    {
        AudioClip uiClip = ResSever.Instance.LoadAudoClip("ResAudio/" + clipName, true);
        uiAudio.clip = uiClip;
        uiAudio.Play();
    }
}
