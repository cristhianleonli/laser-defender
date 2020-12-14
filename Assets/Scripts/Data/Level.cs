
namespace Data
{
    public class Level
    {
        public int id;
        public int starCount;
        public int playedTimes;
        public float minSpawnerFactor;
        public float maxSpawnerFactor;
        public int starsRequired;

        public Level(int id, int starCount, int playedTimes, float minSpawnerFactor, float maxSpawnerFactor, int starsRequired)
        {
            this.id = id;
            this.starCount = starCount;
            this.playedTimes = playedTimes;
            this.minSpawnerFactor = minSpawnerFactor;
            this.maxSpawnerFactor = maxSpawnerFactor;
            this.starsRequired = starsRequired;
        }

        public string Identifier => $"{id + 1}";
        public bool IsEnabled => DataManager.GetStarsCount() >= starsRequired;
        public bool IsPlayed => playedTimes > 0;

        override public string ToString()
        {
            return $"{id}, {starCount}, {playedTimes}, {starsRequired}";
        }
    }
}