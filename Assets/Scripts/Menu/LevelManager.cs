using System.Collections.Generic;
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

        for (int i = 0; i < children.Length; i++)
        {
            children[i].SetTitle($"{i + 1}");
            levels.Add(children[i]);
        }
    }
}
