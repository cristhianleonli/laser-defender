using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private SpriteRenderer background;
    [SerializeField] private SpriteRenderer startA;
    [SerializeField] private SpriteRenderer startB;
    [SerializeField] private SpriteRenderer startC;

    public void SetTitle(string title)
    {
        titleText.text = title;
    }
}
