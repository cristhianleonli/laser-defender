using System.Collections.Generic;

namespace Data
{
    public class DataManager
    {
        private static DataManager instance;
        public static DataManager Instance => instance ?? (instance = new DataManager());

        private readonly List<LevelConfig> levels = new List<LevelConfig>();

        public List<LevelConfig> fetchAll()
        {
            // TODO: Read from db
            levels.Add(new LevelConfig(1, false, 0));
            levels.Add(new LevelConfig(2, false, 0));
            levels.Add(new LevelConfig(3, false, 0));
            levels.Add(new LevelConfig(4, false, 0));
            levels.Add(new LevelConfig(5, false, 0));
            levels.Add(new LevelConfig(6, false, 0));
            levels.Add(new LevelConfig(7, false, 0));
            levels.Add(new LevelConfig(8, true, 0));
            levels.Add(new LevelConfig(9, true, 0));
            levels.Add(new LevelConfig(10, true, 0));
            levels.Add(new LevelConfig(11, true, 0));
            levels.Add(new LevelConfig(12, true, 0));
            levels.Add(new LevelConfig(13, true, 0));
            levels.Add(new LevelConfig(14, true, 0));
            levels.Add(new LevelConfig(15, true, 0));
            levels.Add(new LevelConfig(16, true, 0));
            levels.Add(new LevelConfig(17, true, 0));
            levels.Add(new LevelConfig(18, true, 0));
            levels.Add(new LevelConfig(19, true, 0));
            levels.Add(new LevelConfig(20, true, 0));
            levels.Add(new LevelConfig(21, true, 0));
            levels.Add(new LevelConfig(22, true, 0));
            levels.Add(new LevelConfig(23, true, 0));
            levels.Add(new LevelConfig(24, true, 0));
            levels.Add(new LevelConfig(25, true, 0));
            levels.Add(new LevelConfig(26, true, 0));
            levels.Add(new LevelConfig(27, true, 0));
            levels.Add(new LevelConfig(28, true, 0));

            return levels;
        }

        public void Some()
        {
            levels[0].starCount = 1;
        }
    }
}