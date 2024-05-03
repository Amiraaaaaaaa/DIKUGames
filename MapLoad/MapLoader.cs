namespace Breakout.MapLoad {
    /// <summary>
    /// The MapLoader class is responsible for loading and processing map files.
    /// </summary>
    public class MapLoader {
        private string map;

        /// <summary>
        /// Initializes a new instance of the MapLoader class.
        /// </summary>
        public MapLoader() {
            this.map = "";
        }

        /// <summary>
        /// Loads the content of the map file from the specified URL.
        /// </summary>
        /// <param name="url">The URL of the map file.</param>
        public void LoadFile(string url) {
            //map = File.ReadAllText(url);
            try {
                map = File.ReadAllText(url);
            } catch (Exception ex) {
                Console.WriteLine("Error reading file: " + ex.Message);
                map = ""; // Set default or handle the error as appropriate
            }
        }

        /// <summary>
        /// Parses the level from the loaded map file and returns it as a dictionary. 
        /// The key is a pair of integers representing the coordinate and the value is the character 
        /// at that position.
        /// </summary>
        /// <returns>A dictionary representation of the level.</returns>
        public Dictionary<(int, int), char> LevelTxt() {
            string level = map.Substring(6, map.IndexOf("Map/") - 6);
            var dictionary = new Dictionary<(int, int), char>();
            (int, int) koordinat = (0, 0);
            foreach (char c in level) {
                if (c.Equals('\n') || c.Equals(Environment.NewLine)) {
                    koordinat.Item2++;
                    koordinat.Item1 = 0;
                } else {
                    if (!c.Equals('-') && !c.Equals('\r')) {
                        dictionary.Add(koordinat, c);
                    }
                    koordinat.Item1++;
                }
            }
            return dictionary;
        }

        /// <summary>
        /// Parses the content of the loaded map file and returns it as a dictionary.
        /// The key is a string representing the identifier and the value is the associated content.
        /// </summary>
        /// <param name="lookFor">The identifier to search for in the loaded map content.</param>
        /// <returns>A dictionary of strings extracted from the loaded map content.</returns>
        public Dictionary<string, string> GetTxt(string lookFor) {
            string str = map.Substring(map.IndexOf(lookFor) + lookFor.Length + 3);
            //+3 fordi videre fra stedet, videre fra kolon og videre fra linjeskift
            str = str.Replace("\r", "");
            // \r skal erstattes fordi ellers er der et tegn der skifter linje og er helt weird
            str = str.Substring(0, str.IndexOf(lookFor + "/") - 1);
            //-1 fordi den ellers tager et linjeskift med
            var dictionary = new Dictionary<string, string>();
            List<string> stringList = str.Split('\n').ToList();
            foreach (string s in stringList) {
                dictionary.Add(s.Substring(0, s.IndexOf(' ') - 1), s.Substring(s.IndexOf(' ') + 1));
            }
            return dictionary;
        }
        public Dictionary<string, string> ParseMetaData(string sectionContent) {
            var metaData = new Dictionary<string, string>();
            var lines = sectionContent.Split(new[] {'\n'}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines) {
                var parts = line.Split(':');
                if (parts.Length == 2) {
                    metaData[parts[0].Trim()] = parts[1].Trim();
                }
            }
            return metaData;
        }
    }
}