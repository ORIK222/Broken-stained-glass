﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChipController : MonoBehaviour
{
    [SerializeField] SpriteRenderer _spriteRenderer;
    private StepCounter _stepCounter;

    private Vector3 screenPoint;
    private Vector3 _offset;
    private Vector3 _startPosition;

    private Camera _camera;
    private float _offsetZ;
    private GameManager _gameManager;

    bool _isDisabled;
    private Vector2 _screenBounds;

    private void Awake()
    {
        _camera = Camera.main;
        _screenBounds = _camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _camera.transform.position.z));
        _stepCounter = FindObjectOfType<StepCounter>();
    }

    private void Start()
    {
        _startPosition = transform.position;
    }
    public void Init(GameManager gameManager, Color color)
    {
        _gameManager = gameManager;
        _spriteRenderer.color = color;
    }

    private void OnMouseDown()
    {
        if (_isDisabled) return;
        _offsetZ = Mathf.Repeat(_offsetZ + 0.1f, 1.0f);
        transform.position = new Vector3(transform.position.x, transform.position.y, - _offsetZ);
        screenPoint = _camera.WorldToScreenPoint(transform.position);
        _offset = transform.position - _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void OnMouseDrag()
    {
        if (_isDisabled) return;
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = _camera.ScreenToWorldPoint(cursorPoint) + _offset;
        cursorPosition.x = Mathf.Clamp(cursorPosition.x, -_screenBounds.x, _screenBounds.x);
        cursorPosition.y = Mathf.Clamp(cursorPosition.y, -_screenBounds.y, _screenBounds.y);
        transform.position = cursorPosition;

    }
    private void OnMouseUpAsButton()
    {
        if (_isDisabled) return;
        _gameManager.ChipReleased(_camera.WorldToScreenPoint(transform.position));
        _stepCounter.Count--;
        StepsPanel.stepsPanel.StepsCountText.text = _stepCounter.Count.ToString();
        MovingToStartPosition();
    }

    private void MovingToStartPosition()
    {
        if(transform.position.x > -5.7f && transform.position.x < -0.5f 
           && transform.position.y > -4f && transform.position.y < 2.7f)
        {
            transform.position = Vector3.Lerp(transform.position, _startPosition, 1.0f);
        }
    }

    public void SetDisabled()
    {
        _isDisabled = true;
    }
}
