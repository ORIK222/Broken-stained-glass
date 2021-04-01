using UnityEngine;
using UnityEngine.Events;

public class StepCounter : MonoBehaviour
{
    public static StepCounter stepCounter;
    public int StartCount;
    public int Count;
    public double EndedStepCount;

    private int _temp = 0;

    private void Awake()
    {
        stepCounter = this;
        StartCount = Count;
    }
    private void Start()
    {
        EndedStepCount = Count * 0.3f;
    }
    private void Update()
    {
        if (Count <= 0 && _temp == 0)
        {
            Analizator.IsAnalyze = true;
            _temp++;
        }
    }


}
