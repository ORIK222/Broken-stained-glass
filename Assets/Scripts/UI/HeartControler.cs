using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartControler : MonoBehaviour
{
    [SerializeField] private Heart[] _hearts;
    [SerializeField] private Sprite _darkHeart;

    private void Start()
    {
        _hearts = new Heart[transform.childCount];
        HeartsInit();
    }

    private void HeartsInit()
    {
        for(int i=0;i<_hearts.Length;i++)
        {
            _hearts[i] = transform.GetChild(i).GetComponent<Heart>();
        }
    }

    public void ChangeHeartsState()
    {
        for(int i=0;i<_hearts.Length;i++)
        {
            if (_hearts[i].IsLost == false)
            {
                _hearts[i].IsLost = true;
                _hearts[i].GetComponent<Image>().sprite = _darkHeart;
                break;
            }
            else continue;

        }
    }

}
