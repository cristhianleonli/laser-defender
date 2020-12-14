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

            levels.Add(new Level(0, 2, 1, 0.5f, 1, 0));
            levels.Add(new Level(1, 2, 1, 0.1f, 0.2f, 0));

            for (var i = 2; i < 28; i++)
            {
                levels.Add(
                    new Level(i, 0, 0, 0.1f, 0.5f, 28)
                );
            }

            return levels;
        }

        public static int GetTotalStarsCount()
        {
            return 5;
        }
    }
}