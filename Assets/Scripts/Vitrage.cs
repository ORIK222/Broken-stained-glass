using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vitrage : MonoBehaviour
{
    public void IsAnimationEnd()
    {
        GameManager.gameManager.EndLevelPanelEnabled();
    }
}
