using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class HeartControler : MonoBehaviour
{
    private Heart[] _hearts;
    [SerializeField] private Sprite _darkHeartSprite;

    public UnityEvent LoseEvent;

    private void Start()
    {
        _hearts = new Heart[transform.childCount];
        HeartsInit();
    }
    private void HeartsInit()
    {
        for (int i = 0; i < _hearts.Length; i++)
            _hearts[i] = transform.GetChild(i).GetComponent<Heart>();
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
    }
    public void TestHeart()
    {
        LoseEvent.Invoke();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
