using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private Text _titleText;
    [SerializeField] private Text _winLoseText;
    [SerializeField] private Text _rewardText;
    [SerializeField] private Text _resultText;

    private AudioSource _buttonClickSound;
    private void Start()
    {
        _buttonClickSound = FindObjectOfType<SoundButtonClick>().GetComponent<AudioSource>();
        _titleText.text = "Level " + SceneManager.GetActiveScene().buildIndex.ToString();
        _winLoseText.text = "You win!";
    }
    private void Update()
    {
        if (Analizator.Result >= 75)
          _winLoseText.text = "You win!";
        else
            _winLoseText.text = "You lose!";

        _resultText.text = Analizator.Result.ToString("F0") + "%";
        _rewardText.text = Reward.CoinCount.ToString();
    }

    public void BackToLastScene()
    {
        _buttonClickSound.Play();
        SceneManager.LoadScene("Main");
    }
}
