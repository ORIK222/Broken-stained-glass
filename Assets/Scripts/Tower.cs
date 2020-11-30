using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tower : MonoBehaviour
{

    private void OnMouseDown()
    {
        SceneManager.LoadScene("Level 1");
       //LevelLoader.levelLoader.Load();
    }
}
