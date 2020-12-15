using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public static int LevelCompletedCount = 1;

    private void Start()
    {
        if (PlayerPrefs.GetInt("LevelCount") != 0)
            LevelCompletedCount = PlayerPrefs.GetInt("LevelCount");
    }
}
