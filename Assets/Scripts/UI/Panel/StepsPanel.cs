using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StepsPanel : MonoBehaviour
{
    public static StepsPanel stepsPanel;

    public Text StepsCountText;
    private Text _levelNumberText;
    [SerializeField] private StepCounter _stepCounter;
    private void Awake()
    {
        stepsPanel = this;
    }
    private void Start()
    {
        StepsCountText.text = _stepCounter.Count.ToString();
        _levelNumberText = FindObjectOfType<LevelNumberText>().GetComponent<Text>();
        _levelNumberText.text = SceneManager.GetActiveScene().buildIndex.ToString();
    }
}
