
namespace Data {
    public struct LevelConfig
    {
        public int id;
        public bool isLocked;
        public int starCount;

        public LevelConfig(int id, bool isLocked, int starCount) {
            this.id = id;
            this.isLocked = isLocked;
            this.starCount = starCount;
        }

        public string Identifier => $"{id}";
    }
}
