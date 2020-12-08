using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepsText : MonoBehaviour
{
    public Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }
}
