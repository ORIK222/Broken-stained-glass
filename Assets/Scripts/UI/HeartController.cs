﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HeartController : MonoBehaviour
{
    private Heart[] _hearts;
    private int _repairTime;
    public int LostHeartsCount;


    public UnityEvent LoseEvent;
    public bool IsAllHeartsLost;
    public static HeartController heartController;

    private void Awake()
    {
        heartController = this;
        LostHeartsCount = PlayerPrefs.GetInt("LostHeart");
        if (LostHeartsCount >= 5) PlayerPrefs.SetInt("LostHeart", 5);
        _hearts = new Heart[transform.childCount];
        HeartsInit();
        LostHeartChange();
        if (LostHeartsCount >= _hearts.Length) IsAllHeartsLost = true;
    }
    private void Start()
    {
        _repairTime = 15;
    }
    private void FixedUpdate()
    {
        HeartRepair();
    }
    private void HeartsInit()
    {
        for (int i = 0; i < _hearts.Length; i++)
            _hearts[i] = transform.GetChild(i).GetComponent<Heart>();
    }
    private void LostHeartChange()
    {
        for (int i = 0; i < _hearts.Length; i++)
        {
            _hearts[i].image.color = new Color(0.82f, 0.05f, 0.05f);
        }
        for (int i = 0; i < LostHeartsCount; i++)
        {
            _hearts[i].IsLost = true;
            _hearts[i].image.color = Color.black;
        }
        if (LostHeartsCount >= _hearts.Length) IsAllHeartsLost = true;
        else IsAllHeartsLost = false;
    }
    public void ChangeHeartState()
    {
        LostHeartsCount--;
        TimeController.MinutesPassed -= _repairTime;
    }
    private void HeartRepair()
    {
        for (int i = _hearts.Length - 1; i >= 0; i--)
        {
            if (TimeController.MinutesPassed >= _repairTime)
            {
                if (LostHeartsCount <= 0)
                {
                    TimeController.MinutesPassed = 0;
                    LostHeartsCount = 0;
                }
                else
                {
                    _hearts[i].IsLost = false;
                    _hearts[i].image.color = new Color(0.82f, 0.05f, 0.05f); 
                    LoseEvent.Invoke();
                    PlayerPrefs.SetInt("LostHeart", LostHeartsCount);
                    LostHeartChange();
                }
            }
            else return;
        }

    }
   
}
