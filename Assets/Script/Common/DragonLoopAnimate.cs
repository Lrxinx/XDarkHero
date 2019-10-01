using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonLoopAnimate : MonoBehaviour
{
    private Animation animation;

    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animation>();

        if (animation != null)
            InvokeRepeating("PlayDragonAni", 0, 10);
    }

   void PlayDragonAni()
    {
        animation.Play();
    }
}
