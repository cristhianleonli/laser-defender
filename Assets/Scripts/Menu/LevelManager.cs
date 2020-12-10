using System.Collections.Generic;
using Data;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private readonly List<Level> levels = new List<Level>();

    void Start()
    {
        SetupLevels();
    }

    private void SetupLevels()
    {
        var children = GetComponentsInChildren<Level>();
        var levelConfigs = DataManager.Instance.fetchAll();

        for (int i = 0; i < children.Length; i++)
        {
            children[i].SetConfiguration(levelConfigs[i]);
            levels.Add(children[i]);
        }
    }
}
