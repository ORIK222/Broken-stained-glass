using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public bool IsLost = false;
    [SerializeField] private Sprite _sprite;


    private void Start()
    {
        _sprite = GetComponent<Image>().sprite;

    }
}


