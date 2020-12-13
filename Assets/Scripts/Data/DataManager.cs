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

            for (var i = 0; i < 28; i++)
            {
                levels.Add(
                    new Level(i, Random.Range(0, 4), 0, 0.1f, 0.5f, Random.Range(0, 80))
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