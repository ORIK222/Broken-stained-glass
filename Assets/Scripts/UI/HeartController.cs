using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HeartController : MonoBehaviour
{
    [SerializeField] public Sprite _redHeartSprite;
    [SerializeField] private Sprite _darkHeartSprite;
    private Heart[] _hearts;
    public int LostHeartsCount;


    public UnityEvent LoseEvent;
    public bool IsAllHeartsLost;
    public static HeartController heartController;

    private void Awake()
    {
        heartController = this;
        LostHeartsCount = PlayerPrefs.GetInt("LostHeart");
        _hearts = new Heart[transform.childCount];
        HeartsInit();
        if (LostHeartsCount >= _hearts.Length) IsAllHeartsLost = true;
    }

    private void Start()
    {
        Debug.Log(TimeController.MinutesPassed);
    }

    private void FixedUpdate()
    { 
        HeartRepair(TimeController.MinutesPassed);
    }

    private void HeartsInit()
    {
        for (int i = 0; i < _hearts.Length; i++)
            _hearts[i] = transform.GetChild(i).GetComponent<Heart>();

        for (int i = 0; i < LostHeartsCount; i++)
        {
            _hearts[i].IsLost = true;
            _hearts[i].GetComponent<Image>().sprite = _darkHeartSprite;
        }
        if (LostHeartsCount >= _hearts.Length) IsAllHeartsLost = true;
    }

    public void ChangeHeartState()
    {
        Debug.Log(TimeController.MinutesPassed);
        LostHeartsCount--;
        TimeController.MinutesPassed -= 10;
    }

    private void HeartRepair(float minutes)
    {
        for (int i = _hearts.Length - 1; i >= 0; i--)
        {
            if (minutes >= 10)
            {
                if (LostHeartsCount <= 0)
                {
                    TimeController.MinutesPassed = 0;
                    LostHeartsCount = 0;
                    return;
                }
                _hearts[i].IsLost = false;
                _hearts[i].GetComponent<Image>().sprite = _redHeartSprite;
                LoseEvent.Invoke();
                PlayerPrefs.SetInt("LostHeart", LostHeartsCount);
            }
            else break;
        }
    }
}
