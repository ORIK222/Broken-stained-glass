using UnityEngine;

public class Reward : MonoBehaviour
{
    public static int CoinCount;

    [SerializeField] private AudioClip _winAudioSource;
    [SerializeField] private AudioClip _loseAudioSource;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private RepairVitrageAnimation _correctVitrage;

    private ColorMaker _colorMaker;
    private int _chipCount;

    private void Awake()
    {
        _colorMaker = FindObjectOfType<ColorMaker>();
    }
    private void Start()
    {
        _chipCount = _colorMaker.RTAnalizeSize;
        _audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
    }
    private float GetWinPrize()
    {
        float rewardMulti;
        if (!GameManager.gameManager.IsTime)
            rewardMulti = ((float)StepCounter.stepCounter.Count / (float)StepCounter.stepCounter.StartCount) * (_chipCount - 1.0f) * 150.0f;
        else rewardMulti = ((float)Timer.timer.CurrentTime / (float)Timer.timer.StartTime) * (_chipCount - 1.0f) * 150.0f;
        float reward = 50.0f + rewardMulti;
        float result = _colorMaker.CompareRT();
        var coinCount = reward * result / 100;

        return coinCount;
    } 
    public void LevelResultCalculation()
    {
        if (Analizator.Result >= 75)
        {
            _audioSource.clip = _winAudioSource;
            LevelDataLoader.LevelUnlockedCount++;
            PlayerPrefs.SetInt("LevelCount", LevelDataLoader.LevelUnlockedCount);
            _correctVitrage.gameObject.SetActive(true);
            CoinCount = (int)GetWinPrize();
            Valuta.Coin += CoinCount;
            PlayerPrefs.SetInt("Coin", Valuta.Coin);
        }
        else
        {
            _audioSource.clip = _loseAudioSource;
            CoinCount = 0;
            //HeartController.heartController.LostHeartsCount++;
            //PlayerPrefs.SetInt("LostHeart", HeartController.heartController.LostHeartsCount);
        }
        _audioSource.Play();
    }
}
