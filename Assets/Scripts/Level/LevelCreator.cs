using Data;
using UnityEngine;

public class LevelCreator: MonoBehaviour
{
    public static LevelCreator Instance { get; private set; }

    public LevelConfig CurrentLevelConfig;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
