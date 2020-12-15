using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    [SerializeField] public int _levelNumber;
    [SerializeField] private GameObject _startLevelPanel;
    [SerializeField] private Text _levelNumberText;

    private void OnMouseDown()
    {
        _startLevelPanel.SetActive(true);
        _levelNumberText.text = "Level " + _levelNumber.ToString();
        StartGame.LevelNumber = _levelNumber;
    }
    
}
