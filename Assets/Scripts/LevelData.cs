using UnityEngine;

public class LevelData : MonoBehaviour
{
    public static int LevelUnlockedCount = 1;

    private void Start()
    {
        if (PlayerPrefs.GetInt("LevelCount") < 1) LevelUnlockedCount = 1; 
        else LevelUnlockedCount = PlayerPrefs.GetInt("LevelCount");
        if (LevelUnlockedCount == 4) PlayerPrefs.SetInt("LevelCount", 1);
    }

}
