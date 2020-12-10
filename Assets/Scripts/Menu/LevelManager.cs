using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private List<Level> levels;

    void Start()
    {
        SetupLevels();
    }

    private void SetupLevels()
    {
        levels = new List<Level>();
        var children = GetComponentsInChildren<Level>();
        Debug.Log(children.Length);
        for (int i = 0; i < children.Length; i++)
        {
            children[i].SetTitle($"{i + 1}");
            levels.Add(children[i]);
        }
    }
}
