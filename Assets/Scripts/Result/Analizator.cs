using UnityEngine;

public class Analizator : MonoBehaviour
{
    public static bool IsAnalyze = false; 
    public static float Result;

    private ColorMaker _colorMaker;
    private bool LevelIsEnded;

    public void Analyze()
    {
        GameManager.gameManager.OnEndGame();
        IsAnalyze = false;
        LevelIsEnded = true;
    }

    private void Awake()
    {
        _colorMaker = FindObjectOfType<ColorMaker>();
    }

    private void Update()
    {
        if(!LevelIsEnded)Result = _colorMaker.CompareRT();
        if (IsAnalyze) Analyze();
    }
 
}
