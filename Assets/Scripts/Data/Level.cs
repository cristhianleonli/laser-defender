
using UnityEditor;
using UnityEngine.PlayerLoop;

namespace Data
{
    public class VictoryConditions
    {
        public int asteroidCount;
        public int targetSeconds;

        public VictoryConditions(int asteroidCount, int targetSeconds)
        {
            this.asteroidCount = asteroidCount;
            this.targetSeconds = targetSeconds;
        }
    }

    public class SpawnConfig
    {
        public float minSpawnerFactor;
        public float maxSpawnerFactor;

        public SpawnConfig(float minSpawnerFactor, float maxSpawnerFactor)
        {
            this.minSpawnerFactor = minSpawnerFactor;
            this.maxSpawnerFactor = maxSpawnerFactor;
        }

        // pills
        // shields

        public static SpawnConfig defaultValues()
        {
            return new SpawnConfig(0.5f, 1);
        }
    }

    public class Level
    {
        public int id;

        // no idea what to do with this
        public int starCount; // user saved data
        public int starsRequired;

        public VictoryConditions victoryConditions;
        public SpawnConfig spawnConfig;

        public Level(int id, int starCount, int starsRequired, VictoryConditions victoryConditions, SpawnConfig spawnConfig)
        {
            this.id = id;
            this.starCount = starCount;
            this.starsRequired = starsRequired;
            this.victoryConditions = victoryConditions;
            this.spawnConfig = spawnConfig;
        }

        public string Identifier => $"{id + 1}";
        public bool IsEnabled => DataManager.GetTotalStarsCount() >= starsRequired;

        override public string ToString()
        {
            return $"{id}, {starCount}, {starsRequired}";
        }
    }
}