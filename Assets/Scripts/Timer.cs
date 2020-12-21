using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public static Timer timer;
    public UnityEvent EndLevelEvents;
    public int StartTime;
    public int CurrentTime;
    public double endedTime;

    private int _temp = 0;
    private double _gameTime;

    private void Awake()
    {
        timer = this;
    }
    private void Start()
    {
        StartTime = CurrentTime;
        endedTime = CurrentTime * 0.3f;
    }
    private void FixedUpdate()
    {
        _gameTime += 1 * Time.deltaTime;
        if(_gameTime>=1 && _temp == 0 && !GameManager.gameManager.IsWin)
        {
            CurrentTime -= 1;
            _gameTime = 0;
        }

        if (CurrentTime <= 0 && _temp == 0)
        {
            EndLevelEvents.Invoke();
            _temp++;
        }
    }
}
