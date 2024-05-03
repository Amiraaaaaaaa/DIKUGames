 using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using Breakout.Entities;


namespace Breakout.MapLoad {
    /// <summary>
    /// The MapMaker class is responsible for creating the map of the game.
    /// </summary>
    public class MapMaker {
        private Dictionary<(int, int), char> map;
        private Dictionary<string, string> meta;
        private Dictionary<string, string> legend;
        public Dictionary<string, string> Meta { get => meta; }

        /// <summary>
        /// Initializes a new instance of the MapMaker class.
        /// </summary>
        /// <param name="filePath">The file path to the map file.</param>
        public MapMaker(string filePath) {
            var gameReader = new MapLoader();
            gameReader.LoadFile(filePath);
            map = gameReader.LevelTxt();
            meta = gameReader.GetTxt("Meta");
            legend = gameReader.GetTxt("Legend");
        }

        /// <summary>
        /// Transforms a KeyValuePair representing a tile position and type into a StationaryShape.
        /// </summary>
        /// <param name="kvp">The KeyValuePair to transform, where the key is a pair of integers 
        /// representing the position of the tile and the value is the character representing 
        /// the type of the tile.</param>
        /// <returns>The created StationaryShape.</returns>
        public StationaryShape KVPtoBlockShape(KeyValuePair<(int, int), char> kvp) {
            int xInt = kvp.Key.Item1;
            int yInt = kvp.Key.Item2;

            float widthHeightBoard = 1.0f;
            float numberOfTilesInWidth = 12;
            float numberOfTilesInHeight = 25;

            float tileWidth = widthHeightBoard / numberOfTilesInWidth;
            float tileHeight = widthHeightBoard / numberOfTilesInHeight;

            float xShape = xInt * tileWidth;
            float yShape = (numberOfTilesInHeight - yInt) * tileHeight;

            return new StationaryShape(xShape, yShape, tileWidth, tileHeight);
        }

        /// <summary>
        /// Creates a dictionary of blocks from the map data.
        /// </summary>
        /// <returns>Dictionary of blocks with their positions as keys.</returns>
        public Dictionary<(int, int), Block> BlockDictCreator() {
            var blockDict = new Dictionary<(int, int), Block>();
            foreach (KeyValuePair<(int, int), char> kvp in map) {
                var blockBaseName = legend["" + kvp.Value];
            
                // Here we check if the block name already contains ".png"
                // If it does, we don't append it again.
                var imageName = blockBaseName.EndsWith(".png") ? blockBaseName : $"{blockBaseName}.png";
                var damagedImageName = blockBaseName.EndsWith(".png") 
                    ? $"{blockBaseName.Replace(".png", "")}-damaged.png" 
                    : $"{blockBaseName}-damaged.png";

                // Load the main image and the alternate image
                var mainImage = new Image(Path.Combine("Assets", "Images", imageName));
                var altImage = new Image(Path.Combine("Assets", "Images", damagedImageName));

                // Assume all blocks have 1 hit point initially, unless you specify otherwise
                Block block = new Block(KVPtoBlockShape(kvp), mainImage, altImage, 1);
                blockDict.Add(kvp.Key, block);
            }
            return blockDict;
        }

    }
    
}
