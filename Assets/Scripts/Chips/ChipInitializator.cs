using System.Collections.Generic;
using UnityEngine;

public class ChipInitializator : MonoBehaviour
{
    [SerializeField] private List<Chip> _prefabChip;
    
    private Transform _chipsRootNode;
    private List<Chip> _chips;
    private ColorMaker _colorMaker;
    private int _chipsCount;

    private void Awake()
    {
        _colorMaker = FindObjectOfType<ColorMaker>();
    }
    private void Start()
    {
        _chipsRootNode = transform;
        _chipsCount = _colorMaker.RTAnalizeSize * _colorMaker.RTColorizeSize;
        GenerateChips();
    }
    private void GenerateChips()
    {
        _colorMaker.GetColors();
        _chips = new List<Chip>();
        if (_chipsRootNode.childCount > 0)
        {
            for (int i = _chipsRootNode.childCount - 1; i >= 0; --i)
            {
                Destroy(_chipsRootNode.GetChild(i).gameObject);
            }
        } 

        float offsetX = 6f / _chipsCount;
        float posX = -3f;

        for (int i = 0; i < _chipsCount ; i++)
        {
            Chip tempChip = (Instantiate(_prefabChip[Random.Range(0, _prefabChip.Count)], _chipsRootNode, true));
            tempChip.transform.SetPositionAndRotation(new Vector3(posX, Random.Range(-2.5f, -2.1f) - 0.2f, 0.0f), Quaternion.identity);
            posX += offsetX;

            Chip chip = tempChip;
            chip.Init(_colorMaker.Colors[(int)Mathf.Repeat(i, _colorMaker.Colors.Count)], ChipsSizeCalculation((int)Mathf.Sqrt(_chipsCount)));
            _chips.Add(chip);
        }
    }
    private Vector2 ChipsSizeCalculation(int pieceCount)
    {
        Vector2 chipsSize = new Vector2(1, 1);
        switch (pieceCount)
        {
            case 2:
                {
                    chipsSize = new Vector2(1.4f, 1.4f);
                    break;
                }
            case 3:
                {
                    chipsSize = new Vector2(0.9f, 0.9f);
                    break;
                }
            case 4:
                {
                    chipsSize = new Vector2(0.75f, 0.75f);
                    break;
                }

            default:
                break;
        }

        return chipsSize;
    }
}
