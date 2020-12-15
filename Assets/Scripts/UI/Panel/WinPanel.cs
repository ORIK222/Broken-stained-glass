using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private Text _titleText;
    [SerializeField] private Text _winLoseText;

    private void Start()
    {
        _titleText.text = "Level " + SceneManager.GetActiveScene().buildIndex.ToString();
        _winLoseText.text = "You win!";
    }

    private void Update()
    {
        if (GameManager.gameManager.IsWin) _winLoseText.text = "You win!";
        else _winLoseText.text = "You lose!";
    }
    public void BackToLastScene()
    {
        SceneManager.LoadScene("Main");
    }
}
