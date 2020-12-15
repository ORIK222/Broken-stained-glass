using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    [SerializeField] private int _levelNumber;
    [SerializeField] private GameObject _startLevelPanel;
    [SerializeField] private Text _levelNumberText;

    public bool IsUnlocked;

    private void OnMouseDown()
    {
        if (IsUnlocked)
        {
            _startLevelPanel.SetActive(true);
            _levelNumberText.text = "Level " + _levelNumber.ToString();
            StartGame.LevelNumber = _levelNumber;
        }
    }
    
}
