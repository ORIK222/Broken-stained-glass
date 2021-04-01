using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{    
    public static GameManager gameManager;
    public bool IsTime;

    [SerializeField] private RawImage _originalArtDebug;
    [SerializeField] private RawImage _repairedArtDebug;
    [SerializeField] private RectTransform _endLevelPanel;
    private Chip[] _chips;

    public void OnEndGame()
    {
        _chips = FindObjectsOfType<Chip>();
        _repairedArtDebug.gameObject.SetActive(false);
        _originalArtDebug.gameObject.SetActive(false);
        foreach (var chip in _chips)
        {
            Destroy(chip.gameObject);
        }
        if (Analizator.Result != 100)
            _endLevelPanel.gameObject.SetActive(true);
    }

    private void Awake()
    {
        gameManager = this;
    }

}
