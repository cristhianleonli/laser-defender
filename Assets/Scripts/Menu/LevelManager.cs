using System.Collections.Generic;
using Data;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private readonly List<LevelPanel> panels = new List<LevelPanel>();

    void Start()
    {
        SetupLevels();
    }

    private void SetupLevels()
    {
        var children = GetComponentsInChildren<LevelPanel>();
        var levels = DataManager.FetchLevels();

        for (int i = 0; i < children.Length; i++)
        {
            children[i].SetLevel(levels[i]);
            children[i].OnTapped += OnLevelPanelTapped;
            panels.Add(children[i]);
        }
    }

    private void OnLevelPanelTapped(Level level)
    {
        FindObjectOfType<MenuController>().OpenLevel(level);
    }
}
