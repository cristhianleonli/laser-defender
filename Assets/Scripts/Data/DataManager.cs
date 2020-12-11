using System.Collections.Generic;

namespace Data
{
    public static class DataManager
    {

        public static List<LevelConfig> FetchLevels()
        {
            // TODO: Read from db
            List<LevelConfig> levels = new List<LevelConfig>();

            levels.Add(new LevelConfig(1, 0, false, false));
            levels.Add(new LevelConfig(2, 0, false, false));
            levels.Add(new LevelConfig(3, 0, false, false));
            levels.Add(new LevelConfig(4, 0, false, false));
            levels.Add(new LevelConfig(5, 0, false, false));
            levels.Add(new LevelConfig(6, 0, false, false));
            levels.Add(new LevelConfig(7, 0, false, false));
            levels.Add(new LevelConfig(8, 0, true, false));
            levels.Add(new LevelConfig(9, 0, true, false));
            levels.Add(new LevelConfig(10, 0, true, false));
            levels.Add(new LevelConfig(11, 0, true, false));
            levels.Add(new LevelConfig(12, 0, true, false));
            levels.Add(new LevelConfig(13, 0, true, false));
            levels.Add(new LevelConfig(14, 0, true, false));
            levels.Add(new LevelConfig(15, 0, true, false));
            levels.Add(new LevelConfig(16, 0, true, false));
            levels.Add(new LevelConfig(17, 0, true, false));
            levels.Add(new LevelConfig(18, 0, true, false));
            levels.Add(new LevelConfig(19, 0, true, false));
            levels.Add(new LevelConfig(20, 0, true, false));
            levels.Add(new LevelConfig(21, 0, true, false));
            levels.Add(new LevelConfig(22, 0, true, false));
            levels.Add(new LevelConfig(23, 0, true, false));
            levels.Add(new LevelConfig(24, 0, true, false));
            levels.Add(new LevelConfig(25, 0, true, false));
            levels.Add(new LevelConfig(26, 0, true, false));
            levels.Add(new LevelConfig(27, 0, true, false));
            levels.Add(new LevelConfig(28, 0, true, false));

            return levels;
        }

        public static int GetCoins()
        {
            return 100;
        }
    }
}