using UnityEngine;

public class ChipsTransform : MonoBehaviour
{
    private ChipMover[] _chips;
    [SerializeField] private GameObject[] _correctVitrage;

    private void Start()
    {
        ChipsInit();
    }
    private void ChipsInit()
    {
        _chips = new ChipMover[transform.childCount];
        for (int i = 0; i < _chips.Length; i++)
        {
            _chips[i] = transform.GetChild(i).GetComponent<ChipMover>();
        }
    }
    private void Update()
    { 
        for (int i = 0; i < _chips.Length; i++)
        {
            if (_chips[i] != null && _chips[i].IsCorrect)
            {
                Debug.Log("Destroy");
                Destroy(_chips[i].gameObject);
                _correctVitrage[i].SetActive(true);
            }
        }
    }
}
