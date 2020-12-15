using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    private Tower[] _towers;
    [SerializeField] private Material _grayMaterial;
    [SerializeField] private Material _colorMaterial;
    private void Awake()
    {
        _towers = new Tower[transform.childCount];
        Init();
    }

    private void Start()
    {
        CompleteCheck();
    }

    private void CompleteCheck()
    {
        for (int i = 0; i < _towers.Length; i++)
        {
            _towers[i].transform.GetChild(0).GetComponent<Renderer>().material = _grayMaterial;
            _towers[i].IsUnlocked = false;
        }
        for (int i = 0; i < LevelData.LevelCompletedCount; i++)
        {
            _towers[i].transform.GetChild(0).GetComponent<Renderer>().material = _colorMaterial;
            _towers[i].IsUnlocked = true;
        }

    }
    private void Init()
    {
        for (int i = 0; i < _towers.Length; i++)
        {
            _towers[i] = transform.GetChild(i).GetComponent<Tower>();
        }
    }
}
