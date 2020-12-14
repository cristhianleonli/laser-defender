using TMPro;
using UnityEngine;

public class MenuCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText;

    private void Start()
    {
        SetCoins(20);
    }

    public void SetCoins(int coins)
    {
        coinsText.text = $"{coins}";
    }
}
