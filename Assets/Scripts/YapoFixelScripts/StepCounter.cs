using UnityEngine;
using UnityEngine.Events;

public class StepCounter : MonoBehaviour
{
    public UnityEvent EndLevelEvents; 
    public int Count;
    private void Update()
    {
        if (Count <= 0) EndLevelEvents.Invoke();
    }


}
