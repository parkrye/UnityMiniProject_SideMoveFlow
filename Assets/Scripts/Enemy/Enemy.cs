using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHitable, ITimeScalable
{
    void Awake()
    {
        MainScene.instance.Timer.AddEventListenerOnTimeScaleChangeEvent(ChangeTimeScaleAction);
    }

    public void ChangeTimeScaleAction(float timeScale)
    {

    }

    public void Hit(int damage)
    {

    }
}
