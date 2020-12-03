using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private Text _titleText;


    private void Start()
    {
        _titleText.text = "Level " + SceneManager.GetActiveScene().buildIndex.ToString();
    }
}
