
namespace Data {
    public class LevelConfig
    {
        public int id;
        public int starCount;
        public bool isLocked;
        public bool isPlayed;

        public LevelConfig(int id, int starCount, bool isLocked, bool isPlayed) {
            this.id = id;
            this.starCount = starCount;
            this.isLocked = isLocked;
            this.isPlayed = isPlayed;
        }

        public string Identifier => $"{id}";
    }
}
