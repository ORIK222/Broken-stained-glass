using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    private DateTime _leaveGameTime;
    private DateTime _currentGameTime;

    public static float MinutesPassed;

    private void Awake()
    {
        long temp = Convert.ToInt64(PlayerPrefs.GetString("LeaveTime"));
        _currentGameTime = DateTime.Now;
        _leaveGameTime = DateTime.FromBinary(temp);
    }

    private void Start()
    {
        MinutesPassed = TimeCalculation(_currentGameTime, _leaveGameTime);
    }

    private float TimeCalculation(DateTime currentTime, DateTime leaveTime)
    {
        var timeCount = currentTime - leaveTime;
        var hour = timeCount.Hours;
        var minutes = timeCount.Minutes;
        float minutesPassed = 0;
        for (int i = 0; i < hour; i++)
        {
            minutesPassed += 60;
        }
        minutesPassed += minutes;
        return minutesPassed;
    }

    private void OnApplicationQuit()
    {
        _leaveGameTime = DateTime.Now;
        PlayerPrefs.SetString("LeaveTime", _leaveGameTime.ToBinary().ToString());
    }

}
