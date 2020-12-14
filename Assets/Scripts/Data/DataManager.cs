using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public static class DataManager
    {

        public static List<Level> FetchLevels()
        {
            // TODO: Read from db
            List<Level> levels = new List<Level>();

            levels.Add(new Level(0, 2, 1, 0, 0, 0));
            levels.Add(new Level(1, 0, 1, 0, 0, 0));
            levels.Add(new Level(2, 0, 1, 0, 0, 0));
            levels.Add(new Level(3, 0, 1, 0, 0, 0));
            levels.Add(new Level(4, 0, 1, 0, 0, 0));
            levels.Add(new Level(5, 0, 1, 0, 0, 0));
            levels.Add(new Level(6, 0, 1, 0, 0, 0));

            for (var i = 6; i < 28; i++)
            {
                levels.Add(
                    new Level(i, 0, 0, 0.1f, 0.5f, 28)
                );
            }

            return levels;
        }

        public static int GetStarsCount()
        {
            return 5;
        }
    }
}