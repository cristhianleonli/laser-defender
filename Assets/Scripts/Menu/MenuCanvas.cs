using TMPro;
using UnityEngine;

public class MenuCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText;

    public void SetCoins(int coins)
    {
        coinsText.text = $"{coins}";
    }
}
