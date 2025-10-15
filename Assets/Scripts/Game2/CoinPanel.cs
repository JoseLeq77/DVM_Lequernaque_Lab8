using TMPro;
using UnityEngine;

public class CoinPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;

    private void OnEnable()
    {
        GameManager.OnCoinsUpdate += OnCoinUpdate;
    }

    private void OnDisable()
    {
        GameManager.OnCoinsUpdate -= OnCoinUpdate;
    }

    private void Start()
    {
        coinsText.text = GameManager.Instance.playerCoins.ToString();
    }

    private void OnCoinUpdate(int newCoins)
    {
        if (coinsText != null)
        {
            coinsText.text = newCoins.ToString();
        }
    }
}
