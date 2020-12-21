using UnityEngine;

public class LevelData : MonoBehaviour
{
    public static int LevelUnlockedCount = 1;

    private void Awake()
    {   
        LevelUnlockedCount = PlayerPrefs.GetInt("LevelCount");
        Debug.Log(LevelUnlockedCount);
        if (LevelUnlockedCount == 1) PlayerPrefs.SetInt("LevelCount", 6);
    }
}
