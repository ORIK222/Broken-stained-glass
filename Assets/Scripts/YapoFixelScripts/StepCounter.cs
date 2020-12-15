using UnityEngine;
using UnityEngine.Events;

public class StepCounter : MonoBehaviour
{
    public static StepCounter stepCounter;

    public UnityEvent EndLevelEvents; 
    public int Count;
    private int temp = 0;

    private void Awake()
    {
        stepCounter = this;
    }
    private void Update()
    {
        if (Count <= 0 && temp == 0)
        { 
            EndLevelEvents.Invoke();
            temp++;
        }
    }


}
