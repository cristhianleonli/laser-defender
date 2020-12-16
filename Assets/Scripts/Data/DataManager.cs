using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public static class DataManager
    {

        public static List<Level> FetchLevels()
        {
            // TODO: Read from db or any other persistance method
            List<Level> levels = new List<Level>();

            var conditions1 = new VictoryConditions(5, 10);
            var config1 = new SpawnConfig(0.5f, 1);

            var conditions2 = new VictoryConditions(10, 10);
            var config2 = new SpawnConfig(0.1f, 0.2f);

            levels.Add(new Level(0, 2, 1, conditions1, config1));
            levels.Add(new Level(1, 2, 1, conditions2, config2));

            for (var i = 2; i < 28; i++)
            {
                levels.Add(
                    new Level(i, 0, 20, conditions1, config1)
                );
            }

            return levels;
        }

        public static int GetTotalStarsCount()
        {
            // TODO: read from player preferences
            return 5;
        }
    }
}