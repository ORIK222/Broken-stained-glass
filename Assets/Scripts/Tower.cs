using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tower : MonoBehaviour
{
    [SerializeField] private int _levelNumber;

    private void OnMouseDown()
    {
        SceneManager.LoadScene(_levelNumber);
    }
}
