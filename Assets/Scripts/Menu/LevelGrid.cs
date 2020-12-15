using System.Collections.Generic;
using UnityEngine;
using Data;

public class LevelGrid : MonoBehaviour
{
    [SerializeField] private LevelPanel levelPrefab;

    private GridLayout gridLayout;
    private readonly List<LevelPanel> panels = new List<LevelPanel>();

    void Start()
    {
        gridLayout = GetComponent<GridLayout>();
        SetupLevels();
    }

    private void SetupLevels()
    {
        //var children = GetComponentsInChildren<LevelPanel>();
        var levels = DataManager.FetchLevels();

        for (int i = 0; i < levels.Count; i++)
        {
            //children[i].SetLevel(levels[i]);
            //children[i].OnTapped += OnLevelPanelTapped;
            //panels.Add(children[i]);

            //Instantiate(levelPrefab, )
            //gridLayout.CellToWorld
        }
    }

    private void OnLevelPanelTapped(Level level)
    {
        FindObjectOfType<MenuController>().OpenLevel(level);
    }
}
