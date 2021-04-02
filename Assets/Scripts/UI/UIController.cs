using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController uiController;

    [SerializeField] RectTransform _endLevelPanel;
    [SerializeField] private Button _analizeButton;


    private AudioSource _buttonClickSound;

    private void Start()
    {
        _buttonClickSound = FindObjectOfType<SoundButtonClick>().GetComponent<AudioSource>();
        uiController = this;
    }

    public void ButtonGetColorsOnClick()
    {
        _analizeButton.gameObject.SetActive(true);
    }
    public void ButtonAnalyzeOnClick()
    {
        _buttonClickSound.Play();
        Analizator.IsAnalyze = true;
        _endLevelPanel.gameObject.SetActive(true);
    }
    public void RestartButtonOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void HomeButtonOnClick()
    {
        SceneManager.LoadScene("Main");
    }
    public void EndPanelEnabled()
    {
        _endLevelPanel.gameObject.SetActive(true);
    }
}
