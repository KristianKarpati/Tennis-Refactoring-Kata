namespace Tennis
{
    public class Player
    {
        /// <summary>
        /// Create a new Player with a name
        /// </summary>
        /// <param name="playerName"></param>
        public Player(string playerName)
        {
            name = playerName;
        }
        public int score { get; set; }
        public string name { get; set; }
    }
}
