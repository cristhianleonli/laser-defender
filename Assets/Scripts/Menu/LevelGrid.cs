using System.Collections.Generic;
using UnityEngine;
using Data;
using UnityEngine.UI;

public class LevelGrid : MonoBehaviour
{
    [SerializeField] private LevelPanel levelPrefab;

    private GridLayoutGroup gridLayout;
    private readonly List<LevelPanel> panels = new List<LevelPanel>();

    void Start()
    {
        gridLayout = GetComponent<GridLayoutGroup>();
        SetupLevels();
    }

    private void SetupLevels()
    {
        var levels = DataManager.FetchLevels();
        for (int i = 0; i < levels.Count; i++)
        {
            LevelPanel levelPanel = Instantiate(levelPrefab, gridLayout.transform);
            levelPanel.SetLevel(levels[i]);
            levelPanel.OnTapped += OnLevelPanelTapped;
            panels.Add(levelPanel);
        }
    }

    private void OnLevelPanelTapped(Level level)
    {
        FindObjectOfType<MenuController>().OpenLevel(level);
    }
}
