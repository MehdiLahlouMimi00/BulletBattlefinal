using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{

    #region Singleton "TimerInstance"
    public static TimerManager TimerInstance;

    private void Awake()
    {
        TimerInstance = this;
    }

    #endregion


    private float timer;
    [SerializeField] private TextMeshProUGUI TimerHolder;



    public float getTime()
    {
        return timer;
    }


    public void InitializeTimer(float startingValue)
    {
        timer = startingValue;
        TimerHolder.text = "" + timer;
    }


    public void TimeEvolution()
    {
        timer -= Time.deltaTime;
        TimerHolder.text = timer.ToString("#.#");
    }
    

    

}
