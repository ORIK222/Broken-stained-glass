using UnityEngine;

public class LevelDataLoader : MonoBehaviour
{
    public static int LevelUnlockedCount = 1;

    private void Awake()
    {
        LevelUnlockedCount = PlayerPrefs.GetInt("LevelCount");
        if (LevelUnlockedCount <= 1) PlayerPrefs.SetInt("LevelCount", 1);
        if (LevelUnlockedCount >= 7) PlayerPrefs.SetInt("LevelCount", 1);
    }
}
