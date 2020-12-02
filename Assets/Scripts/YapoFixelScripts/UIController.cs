using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _analizeButton;
    private void Start()
    {
        _startButton.gameObject.SetActive(true);
        _analizeButton.gameObject.SetActive(false);
    }
    public void ButtonGetColorsOnClick()
    {
        _gameManager.GetColors();
        _startButton.gameObject.SetActive(false);
        _analizeButton.gameObject.SetActive(true);
    }

    public void ButtonAnalyzeOnClick()
    {
        _gameManager.Analyze();
    }

    public void RestartButtonOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HomeButtonOnClick()
    {
        SceneManager.LoadScene("Main");
    }

}
