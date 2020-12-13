using Data;
using UnityEngine;

public class LevelCreator: MonoBehaviour
{
    public Level CurrentLevel;
    public static LevelCreator Instance { get; private set; }

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

    public SpawnerConfig GetCurrentSpawnerConfiguration() {
        if (CurrentLevel == null)
        {
            return new SpawnerConfig(1f, 1.5f);
        }

        return new SpawnerConfig(
            CurrentLevel.minSpawnerFactor,
            CurrentLevel.maxSpawnerFactor
        );
    }
}
