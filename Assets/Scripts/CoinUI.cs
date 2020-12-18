using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private Text _coinCountText;

    private void Start()
    {
        _coinCountText.text = Valuta.Coin.ToString();
    }
}
