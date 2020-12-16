using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class HeartController : MonoBehaviour
{
    [SerializeField] private Sprite _darkHeartSprite;
    private Heart[] _hearts;
    private int _lostHeartsCount;

    public UnityEvent LoseEvent;
    public static HeartController heartController;

    private void Awake()
    {
        heartController = this;
        _lostHeartsCount = PlayerPrefs.GetInt("LostHeart");
    }

    private void Start()
    {
        _hearts = new Heart[transform.childCount];
        HeartsInit();
    }
    private void HeartsInit()
    {
        for (int i = 0; i < _hearts.Length; i++)
            _hearts[i] = transform.GetChild(i).GetComponent<Heart>();

        for (int i = 0; i < _lostHeartsCount; i++)
        {
                _hearts[i].IsLost = true;
                _hearts[i].GetComponent<Image>().sprite = _darkHeartSprite;
        }
    }

    public void ChangeHeartsState()
    {
        for (int i = 0; i < _hearts.Length; i++)
        {
            if (!_hearts[i].IsLost)
            {
                _hearts[i].IsLost = true;
                _hearts[i].GetComponent<Image>().sprite = _darkHeartSprite;
                break;
            }
            else continue;
        }
        _lostHeartsCount++;
        PlayerPrefs.SetInt("LostHeart", _lostHeartsCount);
    }
}
