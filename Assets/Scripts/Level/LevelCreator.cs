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

    public SpawnConfig GetCurrentSpawnConfig() {
        if (CurrentLevel == null)
        {
            return SpawnConfig.defaultValues();
        }

        return CurrentLevel.spawnConfig;
    }
}
