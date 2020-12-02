using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public Sprite sprite;
    [SerializeField] private Sprite _redSprite;

    public bool IsLost;

    private void Awake()
    {
        sprite = GetComponent<Sprite>();
    }

    private void Start()
    {
        sprite = _redSprite;
        IsLost = false;
    }
}


