using UnityEngine;

public class LevelData : MonoBehaviour
{
    public static int LevelUnlockedCount = 1;

    private void Awake()
    {   
        LevelUnlockedCount = PlayerPrefs.GetInt("LevelCount");
        if (LevelUnlockedCount >= 7) PlayerPrefs.SetInt("LevelCount", 1);
    }
}
