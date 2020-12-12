﻿using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    [SerializeField] private Image transitionRenderer;
    [SerializeField] private Transform background;

    private void Start()
    {
        transitionRenderer.gameObject.SetActive(false);
        transitionRenderer.DOFade(0, 0);
    }

    public void OnStartButton()
    {
        AudioManager.Instance.PlaySound(SoundType.Hover);
        transitionRenderer.gameObject.SetActive(true);
        transitionRenderer
            .DOFade(1, 0.6f)
            .OnComplete(() => GoToMenuScreen());
    }

    private void GoToMenuScreen()
    {
        SceneManager.LoadScene(Constants.MenuSceneId, LoadSceneMode.Single);
    }
}
